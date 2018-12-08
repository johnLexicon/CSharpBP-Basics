using System;
using NUnit.Framework;

namespace Acme.CommonTestsNUnit
{
    [TestFixture()]
    public class LoggingServiceTests
    {
        [Test()]
        public void LogAction_Success()
        {
            // Arrange
            var loggingService = new LoggingService();
            var expected = "Action: Test Action";

            // Act
            var actual = loggingService.LogAction("Test Action");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
