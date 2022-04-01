using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        public string baseURL = "http://localhost/addressbook/";
        private static ThreadLocal<ApplicationManager>app = new ThreadLocal<ApplicationManager>();

        public IWebDriver Driver { get; }
        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }


        private ApplicationManager()
        {
            Driver = new ChromeDriver();
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
