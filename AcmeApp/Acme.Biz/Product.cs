using System;
namespace Acme.Biz
{
    /// <summary>
    /// Manages prodcuts carried in inventory.
    /// </summary>
    public class Product
    {

        private string productName;
        private string description;
        private int? productId;

        public Product()
        {
            Console.WriteLine("Created an instant of the class Product");
        }

        public Product(int id, string name, string description) : this()
        {
            ProductId = id;
            ProductName = name;
            Description = description;
            Console.WriteLine($"Product name: {ProductName}");
        }

        public string ProductName { get => productName; set => productName = value; }
        public string Description { get => description; set => description = value; }
        public int? ProductId { get => productId; set => productId = value; }

        public string SayHello()
        {
            return $"Hello {ProductId} {ProductName} {Description}".Trim();
        }
    }
}
