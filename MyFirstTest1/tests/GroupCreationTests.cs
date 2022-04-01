using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]

	    public void GroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "Lol",
                Header = "Kek",
                Footer = "Cheburek"
            };

            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]

        public void EmtyGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "Loly",
                Header = null,
                Footer = null
            };

            app.Groups.Create(group);
            app.Auth.Logout();
        }
    }
}

