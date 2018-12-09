using System;
namespace Acme.Biz
{
    /// <summary>
    /// Manages prodcuts carried in inventory.
    /// </summary>
    public class Product
    {

        public readonly decimal MinimumPrice = .5m;

        private string productName;
        private string description;
        private int? productId;
        private Vendor productVendor;

        public Product()
        {
            Console.WriteLine("Created an instant of the class Product");
            MinimumPrice = .99m;
        }

        public Product(int id, string name, string description) : this()
        {
            ProductId = id;
            ProductName = name;
            Description = description;
            Console.WriteLine($"Product name: {ProductName}");
            if (ProductName != null && ProductName.StartsWith("Bulk", StringComparison.Ordinal))
            {
                //The readonly field can be assigned multiple times as long as the it is in a constructor.
                MinimumPrice = 9.99m;
            }
        }

        internal string ProductName { 
            get => productName?.Trim();
            set 
            { 
                if(value.Length < 3)
                {
                    ValidationMessage = "Product name too short";
                }
                else if(value.Length > 20)
                {
                    ValidationMessage = "Product name too long";
                }
                else
                {
                    productName = value;
                }
            } 
        }

        internal string Description { get => description; set => description = value; }
        internal int? ProductId { get => productId; set => productId = value; }

        internal Vendor ProductVendor { 
            get {
                //Lazy loading example (instantiate the object when needed)
                if(productVendor is null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
          } 
            set => productVendor = value;
          }

        internal string ValidationMessage { get; private set; }

        internal string Category { get; set; } = "Tools";
        internal int SequenceNumber { get; set; } = 1;

        public string SayHello()
        {
            return $"Hello {ProductId} {ProductName} {Description}".Trim();
        }
    }
}
