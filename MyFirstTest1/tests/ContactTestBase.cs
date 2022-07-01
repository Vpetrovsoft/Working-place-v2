using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactForm> fromDB = ContactForm.GetAll();
                List<ContactForm> fromUI = appManager.Contacts.GetContactList();
                fromDB.Sort();
                fromUI.Sort();
                Assert.AreEqual(fromDB, fromUI);
            }
            appManager.Auth.Logout();
        }
    }
}