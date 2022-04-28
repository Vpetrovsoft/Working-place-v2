using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        
        public void ContactCreationTest()
        {
            ContactForm contact = new ContactForm()
            {
                LastName = "Bumagad",
                FirstName = "Bitya",
                MiddleName = "Petrovich",
                NickName ="Greshnik215",
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
                BMonth = "May",
                BYear = "1993",
                ADay = "12",
                AMonth = "April",
                AYear = "2021",
                SGroup = "new",
                SAddress = "Lenina",
                SHome = "1",
                SNotes = "Примечание"
            };
            List<ContactForm> oldContacts = appManager.Contacts.GetContactList();

            appManager.Contacts.Creation(contact);

            Assert.AreEqual(oldContacts.Count + 1, appManager.Contacts.GetContactCount());
            List<ContactForm> newContacts = appManager.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            appManager.Auth.Logout();
        }
    }
}