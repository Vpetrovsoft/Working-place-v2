using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactForm> RandomContactDataProvider()
        {
            List<ContactForm> contacts = new List<ContactForm>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactForm()
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
                    Email = GenerateRandomString(10),
                    Email2 = GenerateRandomString(10),
                    Email3 = GenerateRandomString(10),
                    Homepage = GenerateRandomString(10),
                    BDay = GenerateRandomDay(),
                    BMonth = GenerateRandomMonth(),
                    BYear = GenerateRandomYear(10),
                    ADay = GenerateRandomDay(),
                    AMonth = GenerateRandomMonth(),
                    AYear = GenerateRandomYear(10),
                    SGroup = GenerateRandomString(10),
                    SAddress = GenerateRandomString(10),
                    SHome = GenerateRandomPhoneNumber(),
                    SNotes = GenerateRandomString(10)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        
        public void ContactCreationTest(ContactForm contact)
        {
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