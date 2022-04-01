using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.SelectContaсt(0);
            app.Contacts.RemoveContact();
            app.Contacts.ContactCloseAlert();
            app.Auth.Logout();
        }
    }
}
