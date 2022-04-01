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
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            // Проверка
            Assert.IsTrue(app.Auth.isLoggedIn(account));

            app.Auth.Logout();
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            // Готовим тестовую ситуацию
            app.Auth.Logout();

            // Действие
            AccountData account = new AccountData("admin", "1234567");
            app.Auth.Login(account);

            // Проверка
            Assert.IsFalse (app.Auth.isLoggedIn(account));

            app.Auth.Logout();
        }
    }
}
