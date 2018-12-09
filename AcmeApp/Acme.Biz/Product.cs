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

        public string ProductName { get => productName; set => productName = value; }
        public string Description { get => description; set => description = value; }
        public int? ProductId { get => productId; set => productId = value; }

        public string SayHello()
        {
            return $"Hello {ProductId} {ProductName} {Description}".Trim();
        }
    }
}
