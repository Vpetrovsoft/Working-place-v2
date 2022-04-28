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

        private List<GroupData> groupCache = null;

        /// <summary>
        /// Метод, который считает количество элементов в списке и возвращает его.
        /// </summary>
        /// <returns></returns>
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                List<string> groupIdList = new List<string>();
                foreach (IWebElement element in elements)
                {
                    groupIdList.Add(element.FindElement(By.TagName("input")).GetAttribute("value"));                  
                }

                foreach (var item in groupIdList)
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
            manager.Navigator.GoToGroupsPage();
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

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
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
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        /// <summary>
        /// Подтверждение редактирования группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupModifycation()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            groupCache = null;
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