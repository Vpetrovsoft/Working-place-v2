using LinqToDB;


namespace WebAddressbookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        // Вызывает конструктор базового класса и указывает название базы данных
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups => this.GetTable<GroupData>();

        public ITable<ContactForm> Contacts => this.GetTable<ContactForm>();
    }
}
