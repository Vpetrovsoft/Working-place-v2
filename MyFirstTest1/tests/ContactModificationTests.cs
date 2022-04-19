using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
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
                    BMonth = "May",
                    BYear = "1993",
                    ADay = "12",
                    AMonth = "April",
                    AYear = "2021",
                    SGroup = "Lol",
                    SAddress = "Lenina",
                    SHome = "1",
                    SNotes = "Примечание"
                };
                appManager.Contacts.Creation(contact);
            }

            ContactForm newContact = new ContactForm()
            {
                LastName = "Maxim",
                FirstName = "Popoyka",
                MiddleName = "Leonidovich",
                NickName = "Gerakl228",
                Title = "Hello",
                Company = "ООО'ПсковСтройСмесь'",
                Address = "переулок между булок",
                THome = "13",
                TMobile = "8-938-652-88-77",
                TWork = "01-01-20",
                TFax = "01-01-20",
                Email = "Uragantest666+4@gmail.com",
                Email2 = "Uragantest666+5@gmail.com",
                Email3 = "Uragantest666+6@gmail.com",
                Homepage = "www.leningrad12.ru",
                BDay = "11",
                BMonth = "April",
                BYear = "1991",
                ADay = "1",
                AMonth = "November",
                AYear = "2007",
                SGroup = "Lol",
                SAddress = "Lenina",
                SHome = "1",
                SNotes = "о да"
            };
            appManager.Contacts.ModifyContact(0, newContact);
            List<ContactForm> newContacts = appManager.Contacts.GetContactList();
            Assert.AreEqual(oldContacts, newContacts);
            appManager.Auth.Logout();
        }
    }
}
