using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL = "http://localhost/addressbook/";


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
        /// <summary>
        /// Возвращение на главную страницу
        /// </summary>
        protected void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name=\'user\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'user\']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\'submit\']")).Click();
        }
        /// <summary>
        /// Инициализация создания новой группы
        /// </summary>
        protected void InitNewGropCreation()
        {
            driver.FindElement(By.CssSelector("input[name=\'new\']")).Click();
        }
        /// <summary>
        /// Заполнение полей группы
        /// </summary>
        /// <param name="group"></param>
        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name=\'group_header\']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\'group_header\']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name=\'group_footer\']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\'group_footer\']")).SendKeys(group.Footer);
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name=\'submit\']")).Click();
        }
        /// <summary>
        /// Возвращение на странциу группы
        /// </summary>
        protected void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'groups')]")).Click();
        }

        protected void GoToAddContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        /// <summary>
        /// Заполнение полей контакта
        /// </summary>
        /// <param name="contact"></param>
        protected void ContactCreation(ContactForm contact)
        {
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).SendKeys(contact.FirstName);
            driver.FindElement(By.CssSelector("input[name=\"middlename\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"middlename\"]")).SendKeys(contact.MiddleName);
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).SendKeys(contact.LastName);
            driver.FindElement(By.CssSelector("input[name=\"nickname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"nickname\"]")).SendKeys(contact.NickName);
            driver.FindElement(By.CssSelector("input[name=\"title\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"title\"]")).SendKeys(contact.Title);
            driver.FindElement(By.CssSelector("input[name=\"company\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"company\"]")).SendKeys(contact.Company);
            driver.FindElement(By.CssSelector("textarea[name=\"address\"]")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\"address\"]")).SendKeys(contact.Address);
            driver.FindElement(By.CssSelector("input[name=\"home\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"home\"]")).SendKeys(contact.THome);
            driver.FindElement(By.CssSelector("input[name=\"mobile\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"mobile\"]")).SendKeys(contact.TMobile);
            driver.FindElement(By.CssSelector("input[name=\"work\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"work\"]")).SendKeys(contact.TWork);
            driver.FindElement(By.CssSelector("input[name=\"fax\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"fax\"]")).SendKeys(contact.TFax);
            driver.FindElement(By.CssSelector("input[name=\"email\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"email\"]")).SendKeys(contact.Email);
            driver.FindElement(By.CssSelector("input[name=\"email2\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"email2\"]")).SendKeys(contact.Email2);
            driver.FindElement(By.CssSelector("input[name=\"email3\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"email3\"]")).SendKeys(contact.Email3);
            driver.FindElement(By.CssSelector("input[name=\"homepage\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"homepage\"]")).SendKeys(contact.Homepage);

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

        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }

        protected void RemoveGroup()
        {
            driver.FindElement(By.CssSelector("input[name=\"delete\"]")).Click();
        }

        protected void Logout()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
        }

        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        protected void BackToHomePage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
        }

    }
}
