using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    /// <summary>
    /// Class represent product specials with discounted prices.
    /// </summary>
    public class Special
    {
        public List<ProductQuantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
