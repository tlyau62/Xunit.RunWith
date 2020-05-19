using System;
using System.Linq;
using Xunit;
using Xunit.RunWith;

namespace Xunit.RunWithTests
{
    public class RunWithTest : IRunWith
    {
        public void Dispose()
        {
        }

        public void Run(Type type, XunitTest xunitTest)
        {
            foreach (var prop in type.GetProperties().ToArray())
            {
                Assert.Null(prop.GetValue(xunitTest));
                prop.SetValue(xunitTest, new object());
            }
        }
    }

    [RunWith(typeof(RunWithTest))]
    public class UnitTest1 : XunitTest
    {
        public UnitTest1(TestContext context) : base(context)
        {
        }

        public object TestObj { get; set; }

        [Fact]
        public void Test1()
        {
            Assert.NotNull(TestObj);
        }

        [Fact]
        public void Test2()
        {
            Assert.NotNull(TestObj);
        }
    }
}
