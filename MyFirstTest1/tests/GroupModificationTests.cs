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
            List<GroupData> groups = appManager.Groups.GetGroupList();

            if (groups.Count == 0)
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
            appManager.Auth.Logout();
        }
    }
}
