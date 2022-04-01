using System;
using OpenQA.Selenium;

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
            // Если пользовтель залогинен, то выходит, если нет, то логинится
            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                {
                    return;
                }
                Logout();
            }

            Type(By.CssSelector("input[name='user']"), account.Username);
            Type(By.CssSelector("input[name='pass']"), account.Password);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        /// <summary>
        /// Выход
        /// </summary>
        public void Logout()
        {
            // Если кнопки логаут нету, то ничего не делать
            if (isLoggedIn())
            {
                driver.FindElement(By.XPath("//a[contains(text(),'Logout')]")).Click();
            }
        }

        /// <summary>
        /// Метод 
        /// </summary>
        /// <returns></returns>
        public bool isLoggedIn()
        {
            return IsElementPresent(By.CssSelector("form[name='logout'] a"));
        }

        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn()
                && driver.FindElement(By.CssSelector("form[name='logout'] b")).Text == "(" + account.Username + ")";
        }
    }
}
