using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactForm : IEquatable<ContactForm>, IComparable<ContactForm>
    {
        private string allEmails;
        private string allPhones;
 
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
        public int BDay { get; set; }
        public int BMonth { get; set; }
        public string bMonth
        {
            get
            {
                return MonthsOfYear[bMonth].ToString();
            }
            set
            {
                BMonth = MonthsOfYear[value];
            }
        }
        public string BYear { get; set; }

        // Селекторы Anniversary
        public int ADay { get; set; }
        public int AMonth { get; set; }
        public string aMonth
        {
            get
            {
                return MonthsOfYear[aMonth].ToString();
            }
            set
            {
                AMonth = MonthsOfYear[value];
            }
        }
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

        public ContactForm() {}

        public ContactForm(string text) {}

        public string CleanUp(string phoneOrMail)
        {
            if (phoneOrMail == null || phoneOrMail == "")
            {
                return "";
            }
            return phoneOrMail.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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

        public static Dictionary<string, int> MonthsOfYear = new Dictionary<string, int>()
        {
            { "-", 0 },
            { "January", 1 },
            { "February", 2 },
            { "March", 3 },
            { "April", 4 },
            { "May", 5 },
            { "June", 6 },
            { "July", 7 },
            { "August", 8 },
            { "September", 9 },
            { "October", 10 },
            { "November", 11 },
            { "December", 12 }
        };
    }
}
