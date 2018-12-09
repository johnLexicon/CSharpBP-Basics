using System;
using Acme.Common;
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
            var expected = "Action: Test Action";

            // Act
            var actual = LoggingService.LogAction("Test Action");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
