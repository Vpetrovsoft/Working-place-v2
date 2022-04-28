using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
       
        public GroupData() {}

        public GroupData(string text) { }

        /// <summary>
        /// Метод сравнения списков, которые содержат объекты
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(GroupData other)
        {
            // Если объект с которым мы сравниваем, это null, то нужно вернуть false
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            // Если объект равен самому себе, то true
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            //Сравниваем имена
            return Name == other.Name && Header == other.Header && Footer == other.Footer;
        }
        /// <summary>
        /// Метод сравнивающий объекты по хэш-коду
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Name + Header + Footer).GetHashCode();
        }

        /// <summary>
        /// Метод должен вернуть строковое представление объектов типа GroupData (а именно Имя)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nname=" + Name + "\nheader=" + Header + "\nfooter=" + Footer;            
        }

        /// <summary>
        /// Метод сравнения, должен вернуть 1, если текущий объект больше, 0, если равны
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
