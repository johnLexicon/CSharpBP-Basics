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
    }
}
