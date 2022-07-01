using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines("groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData()
                {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        /// <summary>
        /// Помещает данные из XML файла в Лист
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader("groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText("groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]

	    public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            appManager.Groups.Create(group);            
            Assert.AreEqual(oldGroups.Count + 1, appManager.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();            
            Assert.AreEqual(oldGroups, newGroups);
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

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = appManager.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));
            appManager.Auth.Logout();
        }
    }
}

