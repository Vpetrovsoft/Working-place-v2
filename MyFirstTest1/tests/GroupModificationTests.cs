using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            
            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData
                {
                    Name = GenerateRandomString(10),
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10)
                };

                //Добавить группу
                appManager.Groups.Create(group);
                appManager.Navigator.GoToGroupsPage();
            }

            GroupData toBeModify = oldGroups[0];
            GroupData newData = new GroupData
            {
                Name = GenerateRandomString(30),
                Header = GenerateRandomString(30),
                Footer = GenerateRandomString(30)
            };

            appManager.Groups.Modify(toBeModify, newData);

            Assert.AreEqual(oldGroups.Count, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups[0].Header = newData.Header;
            oldGroups[0].Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModify.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                    Assert.AreEqual(newData.Header, group.Header);
                    Assert.AreEqual(newData.Footer, group.Footer);
                }
            }
        }
    }
}
