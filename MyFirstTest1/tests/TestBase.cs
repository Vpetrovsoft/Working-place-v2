using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {

        protected ApplicationManager appManager;

        [SetUp]
        public void SetupApplicationManagerTest()
        {
            appManager = ApplicationManager.GetInstance();
        }
    }
}
