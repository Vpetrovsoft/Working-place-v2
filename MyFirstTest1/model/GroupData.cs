using System;
using OpenQA.Selenium;
using System.Linq;
using LinqToDB.Mapping;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
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

        /// <summary>
        /// Возвращает все данные о группах и БД
        /// </summary>
        /// <returns></returns>
        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        /// <summary>
        /// Возвращает список контактов, которые находятся в определённой группе
        /// </summary>
        /// <returns></returns>
        public List<ContactForm> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p => p.GroupId == Id &&
                        p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}
