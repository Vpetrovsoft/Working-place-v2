using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroupTest()
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

            if (contactListInGroup.Count == 0)
            {
                var contactsInThisGroup = ContactForm.GetAll().Except(contactListInGroup);

                if (contactsInThisGroup.Count() == 0)
                {
                    ContactForm newContactCreate = ContactForm.GetTestContact();
                    appManager.Contacts.Creation(newContactCreate);
                    contactsInThisGroup = ContactForm.GetAll().Except(contactListInGroup);
                }
                ContactForm contactNew = contactsInThisGroup.First();
                appManager.Contacts.AddContactToGroup(contactNew, group);
                contactListInGroup = group.GetContacts();
            }
            ContactForm contact = ContactForm.GetAll().First();

            appManager.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactForm> newListContacts = group.GetContacts();
            contactListInGroup.RemoveAt(0);
            contactListInGroup.Sort();
            newListContacts.Sort();
            Assert.AreEqual(contactListInGroup, newListContacts);
            appManager.Auth.Logout();
        }
    }
}
