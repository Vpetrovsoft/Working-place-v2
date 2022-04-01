using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Removal(0);
            app.Auth.Logout();
        }
    }
}
