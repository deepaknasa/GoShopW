using GoShopW.Contracts;
using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoShopW.Services
{
    public class TrolleyTotalCalculator : ITrolleyTotalCalculator
    {
        public decimal GetTrolleyTotal(Trolley trolley)
        {
            var productsWithPriceAndQuanities = trolley.Products.Join(
                trolley.Quantities,
                p => p.Name,
                q => q.Name,
                (p, q) => new { p.Name, p.Price, q.Quantity })
                .ToDictionary(k => k.Name, v => new { v.Price, v.Quantity, LeftOver = v.Quantity });

            // initialize the total minimum total with actual prices of the products put in the trolley without any specials.
            var minimumTrolleyTotal = productsWithPriceAndQuanities
                .Select(p => p.Value.Quantity * p.Value.Price)
                .Sum();

            foreach (var special in trolley.Specials)
            {
                if (special.Quantities.All(q => productsWithPriceAndQuanities[q.Name].Quantity >= q.Quantity))
                {
                    // this special qualify for calculation.
                    var specialTotal = special.Total;

                    // check if there's any leftover items which can't fit into special offer.
                    specialTotal += special.Quantities.Select(q =>
                    {
                        var productPriceQuantity = productsWithPriceAndQuanities[q.Name];
                        var remainingProductInTrollery = productPriceQuantity.Quantity - q.Quantity;
                        return remainingProductInTrollery * productPriceQuantity.Price;
                    }).Sum(); ;

                    // see if this is the new lowest price.
                    if (specialTotal < minimumTrolleyTotal)
                    {
                        minimumTrolleyTotal = specialTotal;
                    }
                }
            }

            return minimumTrolleyTotal;
        }
    }
}
