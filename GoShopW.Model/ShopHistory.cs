using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    /// <summary>
    /// Class represent shopper history to determine most popular product.
    /// </summary>
    /// <remarks>This is used to determine recommended products order.</remarks>
    public class ShopHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
