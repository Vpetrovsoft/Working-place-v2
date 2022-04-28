using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        private List<ContactForm> contactCache = null;

        /// <summary>
        /// Метод, который считает количество элементов в списке и возвращает его.
        /// </summary>
        /// <returns></returns>
        public List<ContactForm> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactForm>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                List<string> contactIdList = new List<string>();

                foreach (IWebElement element in elements)
                {
                    ContactForm contact = new ContactForm();
                    var tdElements = element.FindElements(By.CssSelector("td"));
                    var contactIDs = element.FindElement(By.TagName("input")).GetAttribute("id");
                    string textFirstName = tdElements[2].Text;
                    contact.FirstName = textFirstName;
                    string textLastName = tdElements[1].Text;
                    contact.LastName = textLastName;
                    string textFullName = tdElements[1].Text + " " + tdElements[2].Text;
                    contact.FullName = textFullName;
                    contact.Id = contactIDs;

                    contactCache.Add(contact);
                }
            }
            return new List<ContactForm>(contactCache);
        }

        /*

            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                List<string> groupIDsList = new List<string>();
                foreach (IWebElement element in elements)
                {
                    groupIDsList.Add(element.FindElement(By.TagName("input")).GetAttribute("value"));                  
                }

                foreach (var item in groupIDsList)
                {
                    GroupData fullGroupModel = new GroupData();
                    driver.FindElement(By.CssSelector("input[name='selected[]'][value='" + item + "']")).Click();
                    InitNewGroupModifycation();
                    fullGroupModel.Id = item;
                    fullGroupModel.Name = driver.FindElement(By.CssSelector("form input[name='group_name']")).GetAttribute("value");
                    fullGroupModel.Header = driver.FindElement(By.CssSelector("form textarea[name='group_header']")).GetAttribute("value");
                    fullGroupModel.Footer = driver.FindElement(By.CssSelector("form textarea[name='group_footer']")).GetAttribute("value");
                    manager.Navigator.GoToGroupsPage();
                    groupCache.Add(fullGroupModel);
                }
            }
            return new List<GroupData>(groupCache);
        */

        /// <summary>
        /// Создание контакта
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public ContactHelper Creation(ContactForm contact)
        {
            manager.Navigator.GoToAddContact();
            ContactFillForm(contact);
            SubmitContactCreation();
            manager.Navigator.BackToHomePage();
            return this;
        }

        /// <summary>
        /// Редактирование контакта
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newContact"></param>
        /// <returns></returns>
        public ContactHelper ModifyContact(int index, ContactForm newContact)
        {
            manager.Navigator.GoToHomePage();
            GoToEditContact(index);
            ContactFillForm(newContact, needFillGroup:false);
            SubmitContactModification();
            manager.Navigator.BackToHomePage();
            return this;
        }

        /// <summary>
        /// Метод передающий количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }

        /// <summary>
        /// Выбор и переход в изменение контакта
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ContactHelper GoToEditContact(int index)
        {
            driver.FindElements(By.CssSelector("table[id=maintable] td:nth-child(8) a"))[index].Click();
            return this;
        }

        /// <summary>
        /// Заполнение полей контакта
        /// </summary>
        /// <param name="contact"></param>
        public ContactHelper ContactFillForm(ContactForm contact, bool needFillGroup = true)
        {
            Type(By.CssSelector("input[name='firstname']"), contact.FirstName);
            Type(By.CssSelector("input[name='middlename']"), contact.MiddleName);
            Type(By.CssSelector("input[name='lastname']"), contact.LastName);
            Type(By.CssSelector("input[name='nickname']"), contact.NickName);
            Type(By.CssSelector("input[name='title']"), contact.Title);
            Type(By.CssSelector("input[name='company']"), contact.Company);
            Type(By.CssSelector("textarea[name='address']"), contact.Address);
            Type(By.CssSelector("input[name='home']"), contact.THome);
            Type(By.CssSelector("input[name='mobile']"), contact.TMobile);
            Type(By.CssSelector("input[name='work']"), contact.TWork);
            Type(By.CssSelector("input[name='fax']"), contact.TFax);
            Type(By.CssSelector("input[name='email']"), contact.Email);
            Type(By.CssSelector("input[name='email2']"), contact.Email2);
            Type(By.CssSelector("input[name='email3']"), contact.Email3);
            Type(By.CssSelector("input[name='homepage']"), contact.Homepage);

            //Заполнение селектора даты рождения
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday']"))).SelectByText(contact.BDay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth']"))).SelectByText(contact.BMonth);
            Type(By.CssSelector("input[name='byear']"), contact.BYear);

            // Селектор Anniversary
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday']"))).SelectByText(contact.ADay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth']"))).SelectByText(contact.AMonth);
            Type(By.CssSelector("input[name='ayear']"), contact.AYear);

            // Селектор выбора группы
            if (needFillGroup)
                new SelectElement(driver.FindElement(By.CssSelector("select[name='new_group']"))).SelectByText(contact.SGroup);

            Type(By.CssSelector("textarea[name='address2']"), contact.SAddress);
            Type(By.CssSelector("input[name='phone2']"), contact.SHome);
            Type(By.CssSelector("textarea[name='notes']"), contact.SNotes);

            return this;
        }

        /// <summary>
        /// Подтверждение создания контакта 
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            contactCache = null;
            return this;
        }

        /// <summary>
        /// Подтверждение изменений при редактировании
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            contactCache = null;
            return this;
        }

        /// <summary>
        /// Метод, который выбирает какой контакт будет удалён
        /// </summary>
        /// <returns></returns>
        public ContactHelper SelectContaсt(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[" + (index + 1) + "]/input")).Click();
            
            return this;
        }

        /// <summary>
        /// Подтверждение удаления контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper ContactCloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        /// <summary>
        /// Удаляет контакт
        /// </summary>
        /// <returns></returns>
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
    }
}