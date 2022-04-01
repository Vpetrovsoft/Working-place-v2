using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData()
            {
                Name = null,
                Header = null,
                Footer = "Modify_Cheburek"
            };
            app.Groups.Modify(0, newData);
            app.Auth.Logout();
        }
    }
}
