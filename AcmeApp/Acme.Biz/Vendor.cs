using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <returns><c>true</c>, if order was placed, <c>false</c> otherwise.</returns>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the order</param>
        public bool PlaceOrder(Product product, int quantity)
        {
            //Safe guard clause
            if(product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            //Safe guard clause
            if(quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            var orderText = $"Order from Acme, Inc {System.Environment.NewLine}Product: {product.ProductName}{System.Environment.NewLine}";
            orderText += $"Quantity: {quantity}";

            bool success = false;

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if(confirmation.StartsWith("Message sent:", StringComparison.Ordinal))
            {
                success = true;
            }

            return success;
        }
    }
}
