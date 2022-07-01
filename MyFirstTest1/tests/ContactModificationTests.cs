using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            List<ContactForm> oldContacts = ContactForm.GetAll();          

            if (oldContacts.Count == 0)
            {
                ContactForm contact = new ContactForm()
                {
                    LastName = GenerateRandomString(10),
                    FirstName = GenerateRandomString(10),
                    MiddleName = GenerateRandomString(10),
                    NickName = GenerateRandomString(10),
                    Title = GenerateRandomString(10),
                    Company = GenerateRandomString(10),
                    Address = GenerateRandomString(10),
                    THome = GenerateRandomPhoneNumber(),
                    TMobile = GenerateRandomPhoneNumber(),
                    TWork = GenerateRandomPhoneNumber(),
                    TFax = GenerateRandomPhoneNumber(),
                    Email = $"{GenerateRandomString(10)}@gmail.com",
                    Email2 = $"{GenerateRandomString(10)}@gmail.com",
                    Email3 = $"{GenerateRandomString(10)}@gmail.com",
                    Homepage = $"{GenerateRandomString(10)}.com",
                    BDay = GenerateRandomDay(),
                    BMonth = GenerateRandomMonth(),
                    BYear = GenerateRandomYear(4),
                    ADay = GenerateRandomDay(),
                    AMonth = GenerateRandomMonth(),
                    AYear = GenerateRandomYear(4),
                    SGroup = GenerateRandomString(10),
                    SAddress = GenerateRandomString(10),
                    SHome = GenerateRandomPhoneNumber(),
                    SNotes = GenerateRandomString(10)
                };
                appManager.Contacts.Creation(contact);
            }

            ContactForm newContact = new ContactForm()
            {
                LastName = GenerateRandomString(10),
                FirstName = GenerateRandomString(10),
                MiddleName = GenerateRandomString(10),
                NickName = GenerateRandomString(10),
                Title = GenerateRandomString(10),
                Company = GenerateRandomString(10),
                Address = GenerateRandomString(10),
                THome = GenerateRandomPhoneNumber(),
                TMobile = GenerateRandomPhoneNumber(),
                TWork = GenerateRandomPhoneNumber(),
                TFax = GenerateRandomPhoneNumber(),
                Email = $"{GenerateRandomString(10)}@gmail.com",
                Email2 = $"{GenerateRandomString(10)}@gmail.com",
                Email3 = $"{GenerateRandomString(10)}@gmail.com",
                Homepage = $"{GenerateRandomString(10)}.com",
                BDay = GenerateRandomDay(),
                BMonth = GenerateRandomMonth(),
                BYear = GenerateRandomYear(4),
                ADay = GenerateRandomDay(),
                AMonth = GenerateRandomMonth(),
                AYear = GenerateRandomYear(4),
                SGroup = GenerateRandomString(10),
                SAddress = GenerateRandomString(10),
                SHome = GenerateRandomPhoneNumber(),
                SNotes = GenerateRandomString(10)
            };
            ContactForm toBeModify = oldContacts[0];
            appManager.Contacts.ModifyContact(toBeModify, newContact);

            Assert.AreEqual(oldContacts.Count, appManager.Contacts.GetContactCount());
            List<ContactForm> newContacts = ContactForm.GetAll();
            oldContacts[0].FirstName = newContact.FirstName;
            oldContacts[0].LastName = newContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactForm contact in newContacts)
            {
                if (contact.Id == toBeModify.Id)
                {
                    Assert.AreEqual(contact.FirstName, newContact.FirstName);
                    Assert.AreEqual(contact.LastName, newContact.LastName);
                }
            }
        }
    }
}
