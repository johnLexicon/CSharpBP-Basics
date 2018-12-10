using Acme.Biz;
using NUnit.Framework;
using System;

namespace Acme.BizTests
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
        public void PlaceOrder_NullProduct_Test()
        {
            //Arrange
            Vendor vendor = new Vendor();
            Product product = null;

            //Act
            try
            {
                var act = vendor.PlaceOrder(product, 4);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail();
        }

        [Test()]
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
            try
            {
                var act = vendor.PlaceOrder(product, 0);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
