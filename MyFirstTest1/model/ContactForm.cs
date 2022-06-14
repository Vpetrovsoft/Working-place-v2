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

        public string FullStringSecondHomePhone 
        {
            get 
            {
                if (SHome != "")
                {
                    return "P: " + SHome;
                }
                return "";
            }
            set { }
        }

        public string FullStringHomepage
        {
            get
            {
                if (Homepage != "")
                {
                    return "Homepage:" + Homepage;
                }
                return "";
            }
            set { }
        }
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

        public string FullStringHomePhone
        {
            get
            {
                if (THome != "")
                {
                    return "H: " + THome;
                }
                return "";
            }
            set { }
        }

        public string FullStringMobilePhone
        {
            get
            {
                if (TMobile != "")
                {
                    return "M: " + TMobile;
                }
                return "";
            }
            set { }
        }

        public string FullStringWorkPhone
        {
            get
            {
                if (TWork != "")
                {
                    return "W: " + TWork;
                }
                return "";
            }
            set { }
        }

        public string FullStringFax
        {
            get
            {
                if (TFax != "")
                {
                    return "F: " + TFax;
                }
                return "";
            }
            set { }
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
                    if (result > 1900 || result < 2023)
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
                    if (result > 1900 || result < 2023)
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

        public string FirstNameWithOutSpace
        {
            get
            {
                if (FirstName != "")
                {
                    return FirstName;
                }
                return "";
            }
            set { }
        }

        public string LastNameWithSpace 
        {
            get
            {
                if (LastName != "")
                {
                    if (FirstName == "" && MiddleName == "")
                    {
                        return LastName;
                    }
                    return " " + LastName;
                }
                return "";
            } 
            set { }
        }
        public string MiddleNameWithSpace
        {
            get
            {
                if (MiddleName != "")
                {
                    if (FirstName == "")
                    {
                        return MiddleName;
                    }
                    return " " + MiddleName;
                }
                return "";
            }
            set { }
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
            convertToString.FirstNameWithOutSpace + Environment.NewLine +
            convertToString.MiddleNameWithSpace + Environment.NewLine +
            convertToString.LastNameWithSpace + Environment.NewLine +
            convertToString.NickName + Environment.NewLine +
            convertToString.Title + Environment.NewLine +
            convertToString.Company + Environment.NewLine +
            convertToString.Address + Environment.NewLine +
            convertToString.FullStringHomePhone + Environment.NewLine +
            convertToString.FullStringMobilePhone + Environment.NewLine +
            convertToString.FullStringWorkPhone + Environment.NewLine +
            convertToString.FullStringFax + Environment.NewLine +
            convertToString.Email + Environment.NewLine +
            convertToString.Email2 + Environment.NewLine +
            convertToString.Email3 + Environment.NewLine +
            convertToString.FullStringHomepage + Environment.NewLine +
            convertToString.FullBirthdayDate + Environment.NewLine +
            convertToString.FullAnniversaryDate + Environment.NewLine +
            convertToString.SAddress + Environment.NewLine +
            convertToString.FullStringSecondHomePhone + Environment.NewLine +
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
    }
}
