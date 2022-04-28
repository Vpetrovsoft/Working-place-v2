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
            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();            
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }

        [Test]

        public void EmtyGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "Loly",
                Header = "change1",
                Footer = "change2",
            };
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();
            appManager.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
            appManager.Auth.Logout();
        }

        [Test]

        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "a'a",
                Header = "b'b",
                Footer = "c'c"
            };
            List<GroupData> oldGroups = appManager.Groups.GetGroupList();

            appManager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();   
            Assert.AreEqual(oldGroups, newGroups);
            appManager.Auth.Logout();
        }
    }
}

