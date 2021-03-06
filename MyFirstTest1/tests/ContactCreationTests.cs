using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactForm> RandomContactDataProvider()
        {
            List<ContactForm> contacts = new List<ContactForm>();
            for (int i = 0; i < 1; i++)
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

        public static IEnumerable<ContactForm> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactForm>>(
                File.ReadAllText("contacts.json"));
        }

        public static IEnumerable<ContactForm> ContactDataFromXmlFile()
        {
            return (List<ContactForm>)new XmlSerializer(typeof(List<ContactForm>))
                .Deserialize(new StreamReader("contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        
        public void ContactCreationTest(ContactForm contact)
        {
            List<ContactForm> oldContacts = ContactForm.GetAll();

            appManager.Contacts.Creation(contact);

            Assert.AreEqual(oldContacts.Count + 1, appManager.Contacts.GetContactCount());
            List<ContactForm> newContacts = ContactForm.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}