using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactForm : IEquatable<ContactForm>, IComparable<ContactForm>
    {
        private string allEmails;
        private string allPhones;
        private string fullBirthdayDate;
        private string fullAnniversaryDate;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string THome { get; set; }
        public string TMobile { get; set; }
        public string TWork { get; set; }
        public string TFax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }

        // Селекторы дня рождения
        public string BDay { get; set; }
        public string BMonth { get; set; }

        public string BYear { get; set; }

        // Селекторы Anniversary
        public string ADay { get; set; }
        public string AMonth { get; set; }

        public string AYear { get; set; }
        // Селектор выбора группы
        public string SGroup { get; set; }
        // Secondary
        public string SAddress { get; set; }
        public string SHome { get; set; }
        public string SNotes { get; set; }

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
                if (fullBirthdayDate != null)
                {
                    return fullBirthdayDate;
                }
                else
                {
                    return CleanUp(BDay) + ". " + CleanUp(BMonth) + " " + CleanUp(BYear);
                }
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
                if (fullAnniversaryDate != null)
                {
                    return fullAnniversaryDate;
                }
                else
                {
                    return CleanUp(ADay) + ". " + CleanUp(AMonth) + " " + CleanUp(AYear);
                }
            }
            set
            {
                fullAnniversaryDate = value;
            }
        }

        public ContactForm() { }

        public ContactForm(string text) { }

        public string CleanUp(string phoneOrMailorDate)
        {
            if (phoneOrMailorDate == null || phoneOrMailorDate == "")
            {
                return "";
            }
            return phoneOrMailorDate.Replace(" ", "").Replace("-", "").Replace("(", "")
                .Replace(")", "").Replace(".", "");
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
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "\n" + "firstName=" + FirstName + ", " + "\n" + "lastName=" + LastName + "\n";
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
                convertToString.FirstName + " " + convertToString.MiddleName + " " + convertToString.LastName + Environment.NewLine +
                convertToString.NickName + Environment.NewLine +
                convertToString.Title + Environment.NewLine +
                convertToString.Company + Environment.NewLine +
                convertToString.Address + Environment.NewLine +
                Environment.NewLine +
                "H: " + convertToString.THome + Environment.NewLine +
                "M: " + convertToString.TMobile + Environment.NewLine +
                "W: " + convertToString.TWork + Environment.NewLine +
                "F: " + convertToString.TFax + Environment.NewLine +
                Environment.NewLine +
                convertToString.Email + Environment.NewLine +
                convertToString.Email2 + Environment.NewLine +
                convertToString.Email3 + Environment.NewLine +
                "Homepage:" + Environment.NewLine + convertToString.Homepage + Environment.NewLine +
                Environment.NewLine +
                "Birthday " + convertToString.FullBirthdayDate + " " + "(" + GetAge(convertToString.BYear) + ")" + Environment.NewLine +
                "Anniversary " + convertToString.FullAnniversaryDate + " " + "(" + GetAge(convertToString.AYear) + ")" + Environment.NewLine +
                Environment.NewLine +
                convertToString.SAddress + Environment.NewLine +
                Environment.NewLine +
                "P: " + convertToString.SHome + Environment.NewLine +
                Environment.NewLine +
                convertToString.SNotes + Environment.NewLine +
                Environment.NewLine +
                Environment.NewLine +
                convertToString.SGroup;

            return allDetails;
        }
        /// <summary>
        /// Возвращает возраст контакта с учётом месяца и дня
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetAge(string count)
        {
            ContactForm contact = new ContactForm();
            var now = DateTime.Today;
            bool valuesOfContact = int.TryParse(count, out int result);

            if (valuesOfContact)
            {
                int calculateYearOfBirth = now.Year - result - 2
                    + (now.Month >= MonthToInt(contact.BMonth) && now.Day >= DayToInt(contact.BDay) ? 1 : 0);
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
            if (dayCheck)
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// Возвращает значение месяца в цифровом формате
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
    }
}
