using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactForm
    {
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

        // Secondary
        public string SAddress { get; set; }
        public string SHome { get; set; }
        public string SNotes { get; set; }

        public ContactForm(
            string firstname,
            string middleName,
            string lastname,
            string nickName,
            string title,
            string company,
            string address,
            string tHome,
            string tMobile,
            string tWork,
            string tFax,
            string email,
            string email2,
            string email3,
            string homepage,
            // Селекторы дня рождения
            string bDay,
            string bMonth,
            string bYear,
            // Secondary
            string sAddress,
            string sHome,
            string sNotes
            )
        {
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middleName;
            NickName = nickName;
            Title = title;
            Company = company;
            Address = address;
            THome = tHome;
            TMobile = tMobile;
            TWork = tWork;
            TFax = tFax;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            // Селекторы дня рождения
            BDay = bDay;
            BMonth = bMonth;
            BYear = bYear;
            // Secondary
            SAddress = sAddress;
            SHome = sHome;
            SNotes = sNotes;
        }
    }
}
