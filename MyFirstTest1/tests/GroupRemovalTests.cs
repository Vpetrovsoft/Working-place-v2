using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToGroupsPage();

            List<GroupData> oldGroups = GroupData.GetAll();

            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData()
                {
                    Name = GenerateRandomString(30),
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(30)
                };
                //Добавить группу
                appManager.Groups.Create(group);
                appManager.Navigator.GoToGroupsPage();
            }
            GroupData toBeRemoved = oldGroups[0];

            appManager.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
