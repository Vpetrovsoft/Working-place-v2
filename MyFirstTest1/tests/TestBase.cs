using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManagerTest()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
