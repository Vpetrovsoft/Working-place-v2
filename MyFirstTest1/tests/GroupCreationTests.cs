using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = GenerateRandomString(30),
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]

	    public void GroupCreationTest(GroupData group)
        {
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

