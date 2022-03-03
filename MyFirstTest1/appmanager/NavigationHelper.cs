using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {

        public string baseURL = "http://localhost/addressbook";

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        /// <summary>
        /// Возвращение на странциу группы
        /// </summary>
        public void GoToGroupsPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'groups')]")).Click();
        }

        /// <summary>
        /// Переход на страницу 'Домой'
        /// </summary>
        public void BackToHomePage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
        }
    }
}