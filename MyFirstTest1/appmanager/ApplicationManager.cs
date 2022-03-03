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
        public string baseURL = "http://localhost/addressbook/";
        public IWebDriver Driver { get; }
        public LoginHelper Auth { get; }
        public NavigationHelper Navigator { get; }
        public GroupHelper Groups { get; }
        public ContactHelper Contacts { get; }


        public ApplicationManager()
        {
            Driver = new ChromeDriver();
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this, baseURL);
            Groups = new GroupHelper(this);
            Contacts = new ContactHelper(this);

        }


        public void Stop()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {

            }
        }

    }
}
