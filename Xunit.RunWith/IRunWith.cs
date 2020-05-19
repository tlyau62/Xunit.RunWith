using System;

namespace Xunit.RunWith
{
    public interface IRunWith : IDisposable
    {
        void Run(Type type, XunitTest xunitTest);
    }
}
