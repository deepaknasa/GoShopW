using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    public class ShopHistory
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
