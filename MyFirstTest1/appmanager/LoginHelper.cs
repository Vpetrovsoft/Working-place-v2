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
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="account"></param>
        public void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name=\'user\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'user\']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).Clear();
            driver.FindElement(By.CssSelector("input[name=\'pass\']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\'submit\']")).Click();
        }

        /// <summary>
        /// Выход
        /// </summary>
        public void Logout()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
        }
    }
}
