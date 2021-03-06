using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsInformationTest()
        {
            ContactForm contactForm = new ContactForm();
            ContactForm fromForm = appManager.Contacts.GetContactInformationFromEditForm(0);
            string fromDetails = appManager.Contacts.GetContactInformationFromDetails(0);

            var fromformToString = (HelperBase.RemoveSpacesAndEnters(ContactForm.GetStringFromForm(fromForm))).Trim();

            var fromDetailsToValid = (HelperBase.RemoveSpacesAndEnters(fromDetails)).Trim();

            Assert.AreEqual(fromDetailsToValid, fromformToString);
            appManager.Auth.Logout();
        }
    }
}
