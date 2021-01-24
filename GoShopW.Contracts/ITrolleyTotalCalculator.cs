using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Contracts
{
    /// <summary>
    /// Helper class which implements trolley total calculations.
    /// </summary>
    public interface ITrolleyTotalCalculator
    {
        /// <summary>
        /// Endpoint which returns minimum total value for all products added in trolley after considering 
        /// all the available specials added in trolley.
        /// </summary>
        /// <param name="trolley">An object represent trolley products data.</param>
        /// <returns>A decimal value indicative of minimum total for all trolley products.</returns>
        decimal GetTrolleyTotal(Trolley trolley);
    }
}
