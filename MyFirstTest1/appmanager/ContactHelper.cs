﻿using System;
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

        public ContactForm GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactForm()
            {
                LastName = lastName,
                FirstName = firstName,
                Address = address,
                AllEmails = allEmail,
                AllPhones = allPhones
            };

        }

        /// <summary>
        /// Возвращает данные из формы редактирования контакта
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ContactForm GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToEditContact(index);
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string secondAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string secondNotes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactForm()
            {
                LastName = lastName,
                FirstName = firstName,
                MiddleName = middleName,
                NickName = nickName,
                Title = title,
                Company = company,
                Address = address,
                THome = homePhone,
                TMobile = mobilePhone,
                TWork = workPhone,
                TFax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                BDay = bday,
                BMonth = bmonth,
                BYear = byear,
                ADay = aday,
                AMonth = amonth,
                AYear = ayear,
                SAddress = secondAddress,
                SHome = secondHomePhone,
                SNotes = secondNotes

            };
        }

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

                foreach (IWebElement element in elements)
                {
                    ContactForm contact = new ContactForm();
                    var tDelements = element.FindElements(By.CssSelector("td"));                                       
                    contact.FirstName = tDelements[2].Text;
                    contact.LastName = tDelements[1].Text;
                    contact.Id = element.FindElement(By.TagName("input")).GetAttribute("id");

                    contactCache.Add(contact);
                }
            }
            return new List<ContactForm>(contactCache);
        }

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