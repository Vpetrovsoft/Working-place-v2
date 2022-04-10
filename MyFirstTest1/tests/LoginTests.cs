using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            // Готовим тестовую ситуацию
            appManager.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "secret");
            appManager.Auth.Login(account);

            // Проверка
            Assert.IsTrue(appManager.Auth.isLoggedIn(account));

            appManager.Auth.Logout();
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            // Готовим тестовую ситуацию
            appManager.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "1234567");
            appManager.Auth.Login(account);

            // Проверка
            Assert.IsFalse (appManager.Auth.isLoggedIn(account));

            appManager.Auth.Logout();
        }
    }
}
