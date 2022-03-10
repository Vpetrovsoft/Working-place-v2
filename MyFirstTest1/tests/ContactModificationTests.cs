using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactForm newContact = new ContactForm()
            {
                LastName = "Maxim",
                FirstName = "Popoyka",
                MiddleName = "Leonidovich",
                NickName = "Gerakl228",
                Title = "Hello",
                Company = "ООО'ПсковСтройСмесь'",
                Address = "переулок между булок",
                THome = "13",
                TMobile = "8-938-652-88-77",
                TWork = "01-01-20",
                TFax = "01-01-20",
                Email = "Uragantest666+4@gmail.com",
                Email2 = "Uragantest666+5@gmail.com",
                Email3 = "Uragantest666+6@gmail.com",
                Homepage = "www.leningrad12.ru",
                BDay = "11",
                BMonth = "April",
                BYear = "1991",
                ADay = "1",
                AMonth = "November",
                AYear = "2007",
                SGroup = "Lol",
                SAddress = "Lenina",
                SHome = "1",
                SNotes = "о да"
            };
            app.Contacts.ModifyContact(1, newContact);
            app.Auth.Logout();
        }
    }
}
