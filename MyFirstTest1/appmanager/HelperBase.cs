using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        /// <summary>
        /// Метод к которому обращаются все методы с заполнением полей
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет наличие текста в поле
        /// </summary>
        /// <param name="text"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string IsStringAvailable(string text, string prefix)
        {
            if (text != "")
            {
                return prefix + text;
            }
            return "";
        }

        /// <summary>
        /// Убирает лишние дублированные пробелы
        /// </summary>
        /// <param name="fromDetails"></param>
        /// <returns></returns>
        public static string RemoveSpacesAndEnters(string fromDetails)
        {
            return System.Text.RegularExpressions.Regex.Replace(fromDetails, @"\s+", " ");
        }
    }
}
