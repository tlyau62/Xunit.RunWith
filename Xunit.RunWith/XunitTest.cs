namespace Xunit.RunWith
{
    public class XunitTest : IClassFixture<XunitTestContext>
    {
        public XunitTest(XunitTestContext context)
        {
            context.Initialize(GetType(), this);
            context.Run(GetType(), this);
        }
    }
}
