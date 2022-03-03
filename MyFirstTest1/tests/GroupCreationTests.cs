using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]

	    public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            GroupData group = new GroupData()
            {
                Name = "Lol",
                Header = "Kek",
                Footer = "Cheburek"
            };
            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}

