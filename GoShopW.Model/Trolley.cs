using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    public class Trolley
    {
        public List<Product> Products { get; set; }
        public List<Special> Specials { get; set; }

        public List<ProductQuantity> Quantities { get; set; }
    }
}
