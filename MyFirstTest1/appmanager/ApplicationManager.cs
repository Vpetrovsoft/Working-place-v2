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
    public class ApplicationManager
    {
        public IWebDriver driver;
        public string baseURL = "http://localhost/addressbook/";
        public LoginHelper loginHelper;
        public NavigationHelper navigator;
        public GroupHelper groupHelper;
        public ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }

        public IWebDriver Driver { get; }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

            }
        }

        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }

    }
}
