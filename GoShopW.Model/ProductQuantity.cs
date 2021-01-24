using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    /// <summary>
    /// Class represents product quantity chosen by retail user while adding product to trolley.
    /// </summary>
    public class ProductQuantity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
