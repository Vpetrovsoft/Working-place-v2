
namespace WebAddressbookTests
{
    public class ContactForm
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

        public ContactForm() {}
    }
}
