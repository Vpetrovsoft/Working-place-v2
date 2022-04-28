using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToGroupsPage();

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();

            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData()
                {
                    Name = "Lol",
                    Header = "Kek",
                    Footer = "Cheburek"
                };

                //Добавить группу
                appManager.Groups.Create(group);
                appManager.Navigator.GoToGroupsPage();
            }
            
            appManager.Groups.SelectGroup(0);
            appManager.Groups.RemoveGroup();

            Assert.AreEqual(oldGroups.Count - 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            appManager.Auth.Logout();
        }
    }
}
