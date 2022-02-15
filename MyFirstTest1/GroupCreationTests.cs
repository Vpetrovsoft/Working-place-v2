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
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private string baseURL = "http://localhost/addressbook/";

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                
            }
        }

        [Test]
        //начало теста
	public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGropCreation();
            FillGroupForm(new GroupData("Lol", "Kek", "Cheburek"));
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
        }

        private void ReturnToGroupPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name=\'submit\']")).Click();
        }

        private void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name=\'group_header\']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\'group_header\']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name=\'group_footer\']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\'group_footer\']")).SendKeys(group.Footer);
        }

        private void InitNewGropCreation()
        {
            driver.FindElement(By.CssSelector("input[name=\'new\']")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name=\'user\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'user\']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\'submit\']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}

