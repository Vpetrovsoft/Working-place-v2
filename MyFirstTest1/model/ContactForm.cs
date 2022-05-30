﻿using System;

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
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
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
                    return (CleanUpPhones(THome) + CleanUpPhones(TMobile) + CleanUpPhones(TWork) + CleanUpPhones(SHome)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public ContactForm() {}

        public ContactForm(string text) {}

        public string CleanUpPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string CleanUpEmails(string mail)
        {
            if (mail == null || mail == "")
            {
                return "";
            }
            return mail.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
    }
}
