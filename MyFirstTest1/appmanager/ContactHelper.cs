﻿using System.Collections.Generic;
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
        /// <param name="v"></param>
        /// <param name="newContact"></param>
        /// <returns></returns>
        public ContactHelper ModifyContact(int v, ContactForm newContact)
        {
            manager.Navigator.GoToHomePage();
            GoToEditContact(v);
            ContactFillForm(newContact, needFillGroup:false);
            SubmitContactModification();
            manager.Navigator.BackToHomePage();
            return this;
        }

        public List<ContactForm> GetContactList()
        {
            List<ContactForm> contacts = new List<ContactForm>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td.center"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactForm(element.Text));
            }
            return contacts;
        }

        /// <summary>
        /// Выбор и переход в изменение контакта
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public ContactHelper GoToEditContact(int v)
        {
            driver.FindElement(By.CssSelector("table[id=maintable] td:nth-child(8) a")).Click();
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
            return this;
        }

        /// <summary>
        /// Подтверждение изменений при редактировании
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }

        /// <summary>
        /// Метод, который выбирает какой контакт будет удалён
        /// </summary>
        /// <returns></returns>
        public ContactHelper SelectContaсt(int index)
        {
            var elements = driver.FindElements(By.CssSelector("[name='selected[]']"));
            if (elements.Count == 0)
            {
                ContactForm contact = new ContactForm()
                {
                    LastName = "Bumagad",
                    FirstName = "Bitya",
                    BDay = "12",
                    BMonth = "May",
                    BYear = "1991",
                    ADay = "11",
                    AMonth = "April",
                    SGroup = "Loly"
                };

                //Добавить контакт
                Creation(contact);
                elements = driver.FindElements(By.CssSelector("[name='selected[]']"));
            }
            elements[index].Click();
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
            return this;
        }
    }
}