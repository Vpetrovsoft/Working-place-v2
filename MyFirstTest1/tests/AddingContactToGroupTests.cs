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
            var contactsNotThisGroup = ContactForm.GetAll().Except(contactListInGroup);
            if (contactsNotThisGroup.Count() == 0)
            {
                var newContactCreate = ContactForm.GetTestContact();
                appManager.Contacts.Creation(newContactCreate);
                contactsNotThisGroup = ContactForm.GetAll().Except(contactListInGroup);
            }
            ContactForm contact = contactsNotThisGroup.First();

            appManager.Contacts.AddContactToGroup(contact, group);

            List<ContactForm> newListContacts = group.GetContacts();
            contactListInGroup.Add(contact);
            contactListInGroup.Sort();
            newListContacts.Sort();
            Assert.AreEqual(contactListInGroup, newListContacts);
            appManager.Auth.Logout();
        }
    }
}
