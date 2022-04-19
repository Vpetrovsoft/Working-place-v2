using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]

	    public void GroupCreationTest()
        {

            GroupData group = new GroupData()
            {
                Name = "Lol",
                Header = "Kek",
                Footer = "Cheburek"
            };
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();       
            appManager.Groups.Create(group);
            
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            appManager.Auth.Logout();
        }

        [Test]

        public void EmtyGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "Loly",
                Header = null,
                Footer = null
            };
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            appManager.Auth.Logout();
        }

        [Test]

        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "a'a",
                Header = null,
                Footer = null
            };
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
            appManager.Auth.Logout();
        }
    }
}

