using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {

        public string baseURL = "http://localhost/addressbook";

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        /// <summary>
        /// Переход на страницу 'Домой'
        /// </summary>
        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        /// <summary>
        /// Возвращение на странциу группы
        /// </summary>
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.XPath("//a[contains(text(),'groups')]")))
            {
                return;
            }
     
            driver.FindElement(By.XPath("//a[contains(text(),'groups')]")).Click();
        }

        /// <summary>
        /// Переход на страницу добавления контакта
        /// </summary>
        public void GoToAddContact()
        {
            //Проверка на нахождение на странице добавления контакта
            if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.CssSelector("input[name='submit']")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        /// <summary>
        /// Переход на страницу 'Домой'
        /// </summary>
        public void BackToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && IsElementPresent(By.XPath("//input[@value='Send e-Mail']")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("a[href='./']")).Click();
        }
    }
}