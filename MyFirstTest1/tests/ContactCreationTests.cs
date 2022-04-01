using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        
        public void ContactCreationTest()
        {
            ContactForm contact = new ContactForm()
            {
                LastName = "Bumagad",
                FirstName = "Bitya",
                MiddleName = "Petrovich",
                NickName ="Greshnik215",
                Title = "",
                Company = "",
                Address = "Мозжевеловый переулок",
                THome = "2",
                TMobile = "8-958-652-88-77",
                TWork = "01-01-00",
                TFax = "01-01-00",
                Email = "Uragantest666+1@gmail.com",
                Email2 = "Uragantest666+2@gmail.com",
                Email3 = "Uragantest666+3@gmail.com",
                Homepage = "www.leningrad.ru",
                BDay = "10",
                BMonth = "May",
                BYear = "1993",
                ADay = "12",
                AMonth = "April",
                AYear = "2021",
                SGroup = "Lol",
                SAddress = "Lenina",
                SHome = "1",
                SNotes = "Примечание"
            };
            app.Contacts.Creation(contact);
            app.Auth.Logout();
        }
    }
}