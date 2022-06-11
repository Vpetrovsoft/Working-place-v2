using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            appManager.Navigator.GoToHomePage();
            List<ContactForm> oldContacts = appManager.Contacts.GetContactList();

            if (oldContacts.Count == 0)
            {
                ContactForm contact = new ContactForm()
                {
                    LastName = "Bumagad",
                    FirstName = "Bitya",
                    MiddleName = "Petrovich",
                    NickName = "Greshnik215",
                    Title = "",
                    Company = "",
                    Address = "Мозжевеловый переулок",
                    THome = "2",
                    TMobile = "8-958-652-88-77",
                    TWork = "01-01-00",
                    TFax = "01-01-00",
                    Email = "Uragantest666+1@gmail.com",
                    Email2 = "Uragantest666+2@gmail.com",
                    Email3 = "Uragantest666+3@gmail.com",
                    Homepage = "www.leningrad.ru",
                    BDay = "10",
                    BMonth = "may",
                    BYear = "1993",
                    ADay = "12",
                    AMonth = "april",
                    AYear = "2021",
                    SGroup = "Lol",
                    SAddress = "Lenina",
                    SHome = "1",
                    SNotes = "Примечание"
                };
                appManager.Contacts.Creation(contact);
            }
            appManager.Contacts.SelectContaсt(0);
            appManager.Contacts.RemoveContact();
            appManager.Contacts.ContactCloseAlert();

            Assert.AreEqual(oldContacts.Count - 1, appManager.Contacts.GetContactCount());
            List<ContactForm> newContacts = appManager.Contacts.GetContactList();
            ContactForm toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactForm contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            appManager.Auth.Logout();
        }
    }
}
