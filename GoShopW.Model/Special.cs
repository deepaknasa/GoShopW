using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    public class Special
    {
        public List<ProductQuantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
