using Acme.Biz;
using NUnit.Framework;
using System;

namespace Acme.BizTestsBizTestsNUnit
{
    [TestFixture()]
    public class VendorTests
    {
        [Test()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void PlaceOrder_Test()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product(1, "Saw", "5 inches jagged saw");
            bool expected = true;

            //Act
            bool actual = vendor.PlaceOrder(product, 4);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Test()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = null;

            //Act
            var act = vendor.PlaceOrder(product, 4);

            //Assert
            //Expected exception
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrder_QuantityLessThanOne_Test()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "5 inches jagged saw"
            };

            //Act
            var act = vendor.PlaceOrder(product, 0);

            //Assert
            //Expected exception
        }
    }
}
