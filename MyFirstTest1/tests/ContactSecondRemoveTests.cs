using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactSecondRemoveTests : TestBase
    {
        [Test]

        public void ContactSecondRemoveTest()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.SelectContaсt(0);
            app.Contacts.RemoveContact();
            app.Contacts.ContactCloseAlert();
            app.Auth.Logout();
        }
    }
}
