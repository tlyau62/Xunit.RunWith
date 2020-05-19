namespace Xunit.RunWith
{
    public class XunitTest : IClassFixture<TestContext>
    {
        public XunitTest(TestContext context)
        {
            context.Initialize(GetType(), this);
            context.Run(GetType(), this);
        }
    }
}
