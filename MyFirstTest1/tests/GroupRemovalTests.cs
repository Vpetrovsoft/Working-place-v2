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
            
            appManager.Groups.SelectGroup(0);
            appManager.Groups.RemoveGroup();
          
            appManager.Auth.Logout();
        }
    }
}
