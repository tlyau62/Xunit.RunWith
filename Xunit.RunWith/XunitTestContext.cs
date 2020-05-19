using System;
using System.Reflection;

namespace Xunit.RunWith
{
    public class TestContext : IDisposable
    {
        private IRunWith _runWith;

        public void Dispose()
        {
            _runWith.Dispose();
            _runWith = null;
        }

        internal void Initialize(Type type, XunitTest xunitTest)
        {
            if (_runWith != null)
            {
                return;
            }

            var runWith = type.GetCustomAttribute<RunWithAttribute>();
            _runWith = (IRunWith)Activator.CreateInstance(runWith.RunWithClass);
        }

        internal void Run(Type type, XunitTest xunitTest)
        {
            _runWith.Run(type, xunitTest);
        }
    }
}
