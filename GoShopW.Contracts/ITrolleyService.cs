using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoShopW.Contracts
{
    /// <summary>
    /// Service class which implements trolley total calculation either via internal <see cref="ITrolleyTotalCalculator"/>
    /// or by external endpoint which returns the total.
    /// </summary>
    public interface ITrolleyService
    {
        /// <summary>
        /// This method returns the trolley total by using external endpoint.
        /// </summary>
        /// <param name="trolley">An object represent trolley data.</param>
        /// <returns>A decimal value indicative of trolley total.</returns>
        Task<decimal> GetTrolleyTotal(Trolley trolley);

        /// <summary>
        /// This method returns the trolley total by using <see cref="ITrolleyTotalCalculator"/>.
        /// </summary>
        /// <param name="trolley">An object represent trolley data.</param>
        /// <returns>A decimal value indicative of trolley total.</returns>
        Task<decimal> GetTrolleyTotalWithCalculatorService(Trolley trolley);
    }
}
