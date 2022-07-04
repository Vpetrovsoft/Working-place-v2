using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGropTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGropTest()
        {
            // Проверяем наличие групп
            List<GroupData> groupList = GroupData.GetAll();
            if (groupList.Count == 0)
            {
                GroupData groupCreate = new GroupData()
                {
                    Name = GenerateRandomString(10),
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10)
                };
                appManager.Groups.Create(groupCreate);
                groupList = GroupData.GetAll();
            }
            // В переменную group записываем группу под индексом 0
            GroupData group = groupList[0];

            // Проверяем наличие контактов
            List<ContactForm> contactList = ContactForm.GetAll();
            if (contactList.Count == 0)
            {
                ContactForm newContactCreate = new ContactForm
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
                    SAddress = GenerateRandomString(10),
                    SHome = GenerateRandomPhoneNumber(),
                    SNotes = GenerateRandomString(10)
                };
                appManager.Contacts.Creation(newContactCreate);
                contactList = ContactForm.GetAll();
            }
            List<ContactForm> oldListContacts = group.GetContacts();
            // Если колчество контактов равно количеству контактов в выбранной группе, тогда создать новый контакт
            if (contactList.Count == oldListContacts.Count)
            {
                ContactForm newContactCreate = new ContactForm
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
                    SAddress = GenerateRandomString(10),
                    SHome = GenerateRandomPhoneNumber(),
                    SNotes = GenerateRandomString(10)
                };
                appManager.Contacts.Creation(newContactCreate);
            }

            ContactForm contact = ContactForm.GetAll().Except(oldListContacts).First();

            appManager.Contacts.AddContactToGroup(contact, group);

            List<ContactForm> newListContacts = group.GetContacts();
            oldListContacts.Add(contact);
            oldListContacts.Sort();
            newListContacts.Sort();
            Assert.AreEqual(oldListContacts, newListContacts);
            appManager.Auth.Logout();
        }
    }
}
