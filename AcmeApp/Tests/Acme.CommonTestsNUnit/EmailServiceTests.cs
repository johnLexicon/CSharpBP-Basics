using Acme.Common;
using NUnit.Framework;
using System;

namespace Acme.CommonTestsNUnit
{
    [TestFixture()]
    public class EmailServiceTests
    {
        [Test()]
        public void SendMessage_Success()
        {
            // Arrange
            var email = new EmailService();
            var expected = "Message sent: Test Message";

            // Act
            var actual = email.SendMessage("Test Message",
                "This is a test message", "abc@abc.com");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
