using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactSecondRemoveTests : AuthTestBase
    {
        [Test]

        public void ContactSecondRemoveTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.SelectContaсt(0);
            app.Contacts.GoToEditContact(0);
            app.Contacts.RemoveContact();
            app.Auth.Logout();
        }
    }
}
