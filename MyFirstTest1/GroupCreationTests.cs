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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGropCreation();
            FillGroupForm(new GroupData("Lol", "Kek", "Cheburek"));
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}

