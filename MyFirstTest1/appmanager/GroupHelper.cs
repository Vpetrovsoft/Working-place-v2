using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public int Count;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
            
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
            Type(By.CssSelector("input[name='group_name']"), group.Name);
            Type(By.CssSelector("textarea[name='group_header']"), group.Header);
            Type(By.CssSelector("textarea[name='group_footer']"), group.Footer);

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
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            
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