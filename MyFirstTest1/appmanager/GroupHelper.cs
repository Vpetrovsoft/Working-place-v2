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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Метод создания группы
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }

        /// <summary>
        /// Метод редактирования группы
        /// </summary>
        /// <param name="v"></param>
        /// <param name="newData"></param>
        /// <returns></returns>
        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitNewGroupModifycation();
            FillGroupForm(newData);
            SubmitGroupModifycation();
            return this;
        }


        /// <summary>
        /// Создать новую группу
        /// </summary>
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
            return this;
        }

        /// <summary>
        /// Заполнение полей группы
        /// </summary>
        /// <param name="group"></param>
        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.Footer);
            return this;
        }

        /// <summary>
        /// Подтверждение создания группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
            return this;
        }

        /// <summary>
        /// Выбор группы из селектора
        /// </summary>
        /// <param name="index"></param>
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
            return this;
        }

        /// <summary>
        /// Подтверждение редактирования группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupModifycation()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }

        /// <summary>
        /// Инициализация редактирования группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper InitNewGroupModifycation()
        {
            driver.FindElement(By.CssSelector("input[name='edit']")).Click();
            return this;
        }
    }
}