using System;
using Acme.Biz;
using NUnit.Framework;

namespace Acme.BizTestsNUnit
{
    [TestFixture()]
    public class ProductTests
    {
        [Test()]
        public void SayHello_WithPropertiesSet_Test()
        {
            //Arrange
            Product p = new Product()
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15 inch jagged saw."
            };
            string expected = "Hello 1 Saw 15 inch jagged saw.";

            //Act
            string actual = p.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void SayHello_NullProperties_Test()
        {
            //Arrange
            Product p = new Product();
            string expected = "Hello";

            //Act
            string actual = p.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void SayHello_Parametized_Test()
        {
            //Arrange
            var p = new Product(2, "Screw driver", "Star headed screw driver size 5.");
            string expected = "Hello 2 Screw driver Star headed screw driver size 5.";

            //Act
            string actual = p.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Product_NULL_Test()
        {
            //Arrange
            Product p = null;
            string companyName = p?.ProductVendor?.CompanyName;
            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void MinimumPrice_Test()
        {
            //Arrange
            Product p = new Product();
            decimal expected = .99m;

            //Act
            decimal actual = p.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void MinimumPrice_BulkProduct_Test()
        {
            //Arrange
            Product p = new Product(1, "Bulk", "My description");
            decimal expected = 9.99m;

            //Act
            decimal actual = p.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ProductName_Test()
        {
            //Arrange
            Product p = new Product
            {
                ProductName = "    Table    "
            };
            string expected = "Table";

            //Act
            string actual = p.ProductName;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsNull(p.ValidationMessage);
        }

        [Test()]
        public void ProductName_TooShort_Test()
        {
            //Arrange
            Product p = new Product
            {
                ProductName = "ab"
            };
            string expected = "Product name too short";

            //Act
            string actual = p.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ProductName_TooLong_Test()
        {
            //Arrange
            Product p = new Product
            {
                ProductName = "abcdefghijklmnopqrstu" //21 characters long
            };
            string expected = "Product name too long";

            //Act
            string actual = p.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
