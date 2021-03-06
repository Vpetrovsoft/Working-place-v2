using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactForm : IEquatable<ContactForm>, IComparable<ContactForm>
    {
        private string allEmails;
        private string allPhones;
        private string fullBirthdayDate;
        private string fullAnniversaryDate;

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string THome { get; set; }

        [Column(Name = "mobile")]
        public string TMobile { get; set; }

        [Column(Name = "work")]
        public string TWork { get; set; }

        [Column(Name = "fax")]
        public string TFax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        // Селекторы дня рождения
        [Column(Name = "bday")]
        public string BDay { get; set; }

        [Column(Name = "bmonth")]
        public string BMonth { get; set; }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        // Селекторы Anniversary
        [Column(Name = "aday")]
        public string ADay { get; set; }

        [Column(Name = "amonth")]
        public string AMonth { get; set; }

        [Column(Name = "ayear")]
        public string AYear { get; set; }
        // Селектор выбора группы
        public string SGroup { get; set; }
        // Secondary
        [Column(Name = "address2")]
        public string SAddress { get; set; }

        [Column(Name = "phone2")]
        public string SHome { get; set; }

        [Column(Name = "notes")]
        public string SNotes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public string AllDetails { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }

            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(THome) + CleanUp(TMobile) + CleanUp(TWork) + CleanUp(SHome)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string FullBirthdayDate
        {
            get
            {
                bool checkYearValid = int.TryParse(BYear, out int result);
                if (fullBirthdayDate != null)
                {
                    return fullBirthdayDate;
                }
                else if (checkYearValid)
                {
                    if (result >= 1900 || result <= 2200)
                    {
                        return "Birthday " + CheckDayToValid(BDay) + CheckMonthToValid(BMonth) +
                            BYear + " " + "(" + GetAge(BDay, BMonth, BYear) + ")";
                    }
                    return "Birthday " + CheckDayToValid(BDay) + CheckMonthToValid(BMonth) + BYear;
                }
                return "Birthday " + CheckDayToValid(BDay) + CheckMonthToValid(BMonth) + BYear;
            }
            set
            {
                fullBirthdayDate = value;
            }
        }

        public string FullAnniversaryDate
        {
            get
            {
                bool checkYearValid = int.TryParse(AYear, out int result);
                if (fullAnniversaryDate != null)
                {
                    return fullAnniversaryDate;
                }
                else if (checkYearValid)
                {
                    if (result >= 1900 || result <= 2200)
                    {
                        return "Anniversary " + CheckDayToValid(ADay) + CheckMonthToValid(AMonth) +
                            AYear + " " + "(" + GetAge(ADay, AMonth, AYear) + ")";
                    }
                    return "Anniversary " + CheckDayToValid(ADay) + CheckMonthToValid(AMonth) + AYear;
                }
                return "Anniversary " + CheckDayToValid(ADay) + CheckMonthToValid(AMonth) + AYear;
            }
            set
            {
                fullAnniversaryDate = value;
            }
        }

        public ContactForm() { }

        public ContactForm(string text) { }

        /// <summary>
        /// Убирает лишние символы -(). и пробел
        /// </summary>
        /// <param name="phoneOrMailorDate"></param>
        /// <returns></returns>
        public string CleanUp(string phoneOrMailorDate)
        {
            if (phoneOrMailorDate == null || phoneOrMailorDate == "")
            {
                return "";
            }
            return phoneOrMailorDate.Replace(" ", "").Replace("-", "").Replace("(", "")
                .Replace(")", "").Replace(".", "");
        }

        /// <summary>
        /// Проверяет проставлен ли месяц в селекторе
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public string CheckMonthToValid(string month)
        {
            if (month != "-")
            {
                return month + " ";
            }
            return "";
        }

        /// <summary>
        /// Проверяет валидное ли значения дня выбрано
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public string CheckDayToValid(string day)
        {
            if (day != "0")
            {
                return day + ". ";
            }
            return "";
        }

        public bool Equals(ContactForm other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "\n" + "firstName=" + FirstName + ", " +
            "\n" + "lastName=" + LastName + ", " +
            "\n" + "nickName=" + NickName + ", " +
            "\n" + "title=" + Title + ", " +
            "\n" + "company=" + Company + ", " +
            "\n" + "address=" + Address + ", " +
            "\n" + "homePhone=" + THome + ", " +
            "\n" + "mobilePhone=" + TMobile + ", " +
            "\n" + "workPhone=" + TWork + ", " +
            "\n" + "fax=" + TFax + ", " +
            "\n" + "email=" + Email + ", " +
            "\n" + "email2=" + Email2 + ", " +
            "\n" + "email3=" + Email3 + ", " +
            "\n" + "homepgae=" + Homepage + ", " +
            "\n" + "birthDay=" + BDay + ", " +
            "\n" + "birthMonth=" + BMonth + ", " +
            "\n" + "birthYear=" + BYear + ", " +
            "\n" + "anniversaryDay=" + ADay + ", " +
            "\n" + "anniversaryMonth=" + AMonth + ", " +
            "\n" + "anniversaryYear=" + AYear + ", " +
            "\n" + "secondAddress=" + SAddress + ", " +
            "\n" + "secondHomePhone=" + SHome + ", " +
            "\n" + "secondNotes=" + SNotes + ", ";
        }

        public int CompareTo(ContactForm other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            var res = FirstName.CompareTo(other.FirstName);

            if (res == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return res;
        }

        /// <summary>
        /// Возвращает строку из формы
        /// </summary>
        /// <param name="convertToString"></param>
        /// <returns></returns>
        public static string GetStringFromForm(ContactForm convertToString)
        {
            string allDetails =
            HelperBase.IsStringAvailable(convertToString.FirstName, " ") + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.MiddleName, " ") + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.LastName, " ") + Environment.NewLine +
            convertToString.NickName + Environment.NewLine +
            convertToString.Title + Environment.NewLine +
            convertToString.Company + Environment.NewLine +
            convertToString.Address + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.THome, "H: ") + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.TMobile, "M: ") + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.TWork, "W: ") + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.TFax, "F: ") + Environment.NewLine +
            convertToString.Email + Environment.NewLine +
            convertToString.Email2 + Environment.NewLine +
            convertToString.Email3 + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.Homepage, "Homepage: ") + Environment.NewLine +
            convertToString.FullBirthdayDate + Environment.NewLine +
            convertToString.FullAnniversaryDate + Environment.NewLine +
            convertToString.SAddress + Environment.NewLine +
            HelperBase.IsStringAvailable(convertToString.SHome, "P: ") + Environment.NewLine +
            convertToString.SNotes + Environment.NewLine +
            convertToString.SGroup + Environment.NewLine;
            return allDetails;
        }


        /// <summary>
        /// Возвращает возраст контакта с учётом месяца и дня
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetAge(string day, string month, string year)
        {
            var now = DateTime.Today;
            bool valuesOfContact = int.TryParse(year, out int result);

            if (valuesOfContact)
            {
                int calculateYearOfBirth = now.Year - result - 1
                    + (now.Month >= MonthToInt(month) && now.Day >= DayToInt(day) ? 1 : 0);
                string resultOfCalculate = Convert.ToString(calculateYearOfBirth);
                return resultOfCalculate;
            }
            return "";
        }
        /// <summary>
        /// Возвращает день как число
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int DayToInt(string day)
        {
            bool dayCheck = int.TryParse(day, out int result);
            if (dayCheck && result < 31)
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// Возвращает значение месяца в цифровом формате. Только для калькулятора.
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int MonthToInt(string month)
        {
            var collection = new Dictionary<int, string>
            {
                { 0, "-" },
                { 1, "January" },
                { 2, "February" },
                { 3, "March" },
                { 4, "April" },
                { 5, "May" },
                { 6, "June" },
                { 7, "July" },
                { 8, "August" },
                { 9, "September" },
                { 10, "October" },
                { 11, "November" },
                { 12, "December" },
            };
            foreach (var item in collection)
            {
                if (month == item.Value)
                {
                    return item.Key;
                }
            }
            return 0;
        }

        public static List<ContactForm> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        /// <summary>
        /// Возвращает валидный контакт
        /// </summary>
        /// <returns></returns>
        public static ContactForm GetTestContact()
        {
            ContactForm newContactCreate = new ContactForm
            {
                LastName = "Vitya",
                FirstName = "Bumaga",
                BDay = "4",
                BMonth = "April",
                ADay = "12",
                AMonth = "May"
            };
            return newContactCreate;
        }
    }
}
