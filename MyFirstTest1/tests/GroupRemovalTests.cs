using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup();
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        }
    }
}
