using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
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

            GroupData newData = new GroupData()
            {
                Name = null,
                Header = null,
                Footer = "Modify_Cheburek"
            };
            appManager.Groups.Modify(0, newData);
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }
    }
}
