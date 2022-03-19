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
            ContactFillForm(newContact);
            SubmitContactModification();
            manager.Navigator.BackToHomePage();
            return this;
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
        public ContactHelper ContactFillForm(ContactForm contact)
        {
            driver.FindElement(By.CssSelector("input[name='firstname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='firstname']")).SendKeys(contact.FirstName);
            driver.FindElement(By.CssSelector("input[name='middlename']")).Clear();
            driver.FindElement(By.CssSelector("input[name='middlename']")).SendKeys(contact.MiddleName);
            driver.FindElement(By.CssSelector("input[name='lastname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='lastname']")).SendKeys(contact.LastName);
            driver.FindElement(By.CssSelector("input[name='nickname']")).Clear();
            driver.FindElement(By.CssSelector("input[name='nickname']")).SendKeys(contact.NickName);
            driver.FindElement(By.CssSelector("input[name='title']")).Clear();
            driver.FindElement(By.CssSelector("input[name='title']")).SendKeys(contact.Title);
            driver.FindElement(By.CssSelector("input[name='company']")).Clear();
            driver.FindElement(By.CssSelector("input[name='company']")).SendKeys(contact.Company);
            driver.FindElement(By.CssSelector("textarea[name='address']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address']")).SendKeys(contact.Address);
            driver.FindElement(By.CssSelector("input[name='home']")).Clear();
            driver.FindElement(By.CssSelector("input[name='home']")).SendKeys(contact.THome);
            driver.FindElement(By.CssSelector("input[name='mobile']")).Clear();
            driver.FindElement(By.CssSelector("input[name='mobile']")).SendKeys(contact.TMobile);
            driver.FindElement(By.CssSelector("input[name='work']")).Clear();
            driver.FindElement(By.CssSelector("input[name='work']")).SendKeys(contact.TWork);
            driver.FindElement(By.CssSelector("input[name='fax']")).Clear();
            driver.FindElement(By.CssSelector("input[name='fax']")).SendKeys(contact.TFax);
            driver.FindElement(By.CssSelector("input[name='email']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email']")).SendKeys(contact.Email);
            driver.FindElement(By.CssSelector("input[name='email2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email2']")).SendKeys(contact.Email2);
            driver.FindElement(By.CssSelector("input[name='email3']")).Clear();
            driver.FindElement(By.CssSelector("input[name='email3']")).SendKeys(contact.Email3);
            driver.FindElement(By.CssSelector("input[name='homepage']")).Clear();
            driver.FindElement(By.CssSelector("input[name='homepage']")).SendKeys(contact.Homepage);

            //Заполнение селектора даты рождения
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday']"))).SelectByText(contact.BDay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth']"))).SelectByText(contact.BMonth);
            driver.FindElement(By.CssSelector("input[name='byear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='byear']")).SendKeys(contact.BYear);

            // Селектор Anniversary
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday']"))).SelectByText(contact.ADay);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth']"))).SelectByText(contact.AMonth);
            driver.FindElement(By.CssSelector("input[name='ayear']")).Clear();
            driver.FindElement(By.CssSelector("input[name='ayear']")).SendKeys(contact.AYear);

            try
            {
                // Селектор выбора группы
                new SelectElement(driver.FindElement(By.CssSelector("select[name='new_group']"))).SelectByText(contact.SGroup);
            }
            catch (Exception)
            {
            }

            driver.FindElement(By.CssSelector("textarea[name='address2']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address2']")).SendKeys(contact.SAddress);
            driver.FindElement(By.CssSelector("input[name='phone2']")).Clear();
            driver.FindElement(By.CssSelector("input[name='phone2']")).SendKeys(contact.SHome);
            driver.FindElement(By.CssSelector("textarea[name='notes']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='notes']")).SendKeys(contact.SNotes);

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
            if (elements.Count < 1)
            {
                //Добавить контакт
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