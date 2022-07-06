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
            GroupData group = groupList[0];

            List<ContactForm> contactListInGroup = group.GetContacts();
 
            List<ContactForm> contactList = ContactForm.GetAll();
            if (contactList.Count == 0)
            {
                ContactForm newContactCreate = new ContactForm
                {
                    LastName = "Vitya",
                    FirstName = "Bumaga",
                    BDay = "4",
                    BMonth = "April",
                    ADay = "12",
                    AMonth = "May"
                };
                appManager.Contacts.Creation(newContactCreate);
                contactList = ContactForm.GetAll();
            }            
            // Если разница всех контактов и контактов в группе равна 0
            if (contactList.Count - contactListInGroup.Count == 0)
            {
                ContactForm newContactCreate = new ContactForm
                {
                    LastName = "Osetr",
                    FirstName = "Maxim",
                    BDay = "4",
                    BMonth = "April",
                    ADay = "12",
                    AMonth = "May"
                };
                appManager.Contacts.Creation(newContactCreate);
                contactList = ContactForm.GetAll();
            }

            ContactForm contact = contactList.Except(contactListInGroup).First();

            appManager.Contacts.AddContactToGroup(contact, group.Id);

            List<ContactForm> newListContacts = group.GetContacts();
            contactListInGroup.Add(contact);
            contactListInGroup.Sort();
            newListContacts.Sort();
            Assert.AreEqual(contactListInGroup, newListContacts);
            appManager.Auth.Logout();
        }
    }
}
