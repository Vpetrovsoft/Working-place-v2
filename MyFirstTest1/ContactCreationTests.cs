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
    public class ContactCreationTests
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
        
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddContact();

            ContactForm contact = new ContactForm()
            {
                LastName = "Bumaga",
                FirstName = "Bitya",
                MiddleName = "Petrovich",
                NickName ="Greshnik215",
                Title = "Титул",
                Company = "ООО'ПсковСтройСемью'",
                Address = "Мозжевеловый переулок",
                THome = "2",
                TMobile = "8-958-652-88-77",
                TWork = "01-01-00",
                TFax = "01-01-00",
                Email = "Uragantest666+1@gmail.com",
                Email2 = "Uragantest666+2@gmail.com",
                Email3 = "Uragantest666+3@gmail.com",
                Homepage = "www.leningrad.ru",
                BDay = "10",
                BMonth = "May",
                BYear = "1993",
                ADay = "12",
                AMonth = "April",
                AYear = "2021",
                SGroup = "Lol",
                SAddress = "Lenina",
                SHome = "1",
                SNotes = "Примечание",

            };
            ContactCreation(contact);
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout'] a")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private void GoToAddContact()
        {
            // Тут возможно привязка только к ссылке
            driver.FindElement(By.CssSelector("a[href='edit.php']")).Click();
        }

        /// <summary>
        /// Метод заполнения всех полей при создании контакта
        /// </summary>
        /// <param name="contact"></param>
        private void ContactCreation(ContactForm contact)
        {
            driver.FindElement(By.CssSelector("input[name='firstname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys(contact.FirstName);
            driver.FindElement(By.CssSelector("input[name='middlename']")).Clear();
            driver.FindElement(By.CssSelector("input[name='middlename']")).SendKeys(contact.MiddleName);
            driver.FindElement(By.CssSelector("input[name='lastname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys(contact.LastName);
            driver.FindElement(By.CssSelector("input[name='nickname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='nickname']")).SendKeys(contact.NickName);
            driver.FindElement(By.CssSelector("input[name='title']")).Clear();
            driver.FindElement(By.CssSelector("input[name='title']")).SendKeys(contact.Title);
            driver.FindElement(By.CssSelector("input[name='company']")).Clear();
            driver.FindElement(By.CssSelector("input[name='company']")).SendKeys(contact.Company);
            driver.FindElement(By.CssSelector("textarea[name='address']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address']")).SendKeys(contact.Address);
            driver.FindElement(By.CssSelector("input[name='home']")).Clear();
            driver.FindElement(By.CssSelector("input[name='home']")).SendKeys(contact.THome);
            driver.FindElement(By.CssSelector("input[name='mobile']")).Clear();
            driver.FindElement(By.CssSelector("input[name='mobile']")).SendKeys(contact.TMobile);
            driver.FindElement(By.CssSelector("input[name='work']")).Clear();
            driver.FindElement(By.CssSelector("input[name='work']")).SendKeys(contact.TWork);
            driver.FindElement(By.CssSelector("input[name='fax']")).Clear();
            driver.FindElement(By.CssSelector("input[name='fax']")).SendKeys(contact.TFax);
            driver.FindElement(By.CssSelector("input[name='email']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(contact.Email);
            driver.FindElement(By.CssSelector("input[name='email2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email2']")).SendKeys(contact.Email2);
            driver.FindElement(By.CssSelector("input[name='email3']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email3']")).SendKeys(contact.Email3);
            driver.FindElement(By.CssSelector("input[name='homepage']")).Clear();
            driver.FindElement(By.CssSelector("input[name='homepage']")).SendKeys(contact.Homepage);

            //Заполнение селектора даты рождения
            driver.FindElement(By.CssSelector("form[name='theform']")).Click();
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday']"))).SelectByText(contact.BDay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth']"))).SelectByText(contact.BMonth);
            driver.FindElement(By.CssSelector("input[name='byear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='byear']")).SendKeys(contact.BYear);

            // Селектор Anniversary
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday']"))).SelectByText(contact.ADay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth']"))).SelectByText(contact.AMonth);
            driver.FindElement(By.CssSelector("input[name='ayear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='ayear']")).SendKeys(contact.AYear);

            // Селектор выбора группы
            new SelectElement(driver.FindElement(By.CssSelector("select[name='new_group']"))).SelectByText(contact.SGroup);

            driver.FindElement(By.CssSelector("textarea[name='address2']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address2']")).SendKeys(contact.SAddress);
            driver.FindElement(By.CssSelector("input[name='phone2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='phone2']")).SendKeys(contact.SHome);
            driver.FindElement(By.CssSelector("textarea[name='notes']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='notes']")).SendKeys(contact.SNotes);
        }

    }
}