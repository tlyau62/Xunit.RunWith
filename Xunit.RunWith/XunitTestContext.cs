using System;
using System.Reflection;

namespace Xunit.RunWith
{
    public class XunitTestContext : IDisposable
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

            if (runWith == null)
            {
                throw new InvalidOperationException("No run with class is found.");
            }

            _runWith = (IRunWith)Activator.CreateInstance(runWith.RunWithClass);
        }

        internal void Run(Type type, XunitTest xunitTest)
        {
            _runWith.Run(type, xunitTest);
        }
    }
}
