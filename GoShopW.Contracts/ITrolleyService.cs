using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoShopW.Contracts
{
    public interface ITrolleyService
    {
        Task<decimal> GetTrolleyTotal(Trolley trolley);
        Task<decimal> GetTrolleyTotalWithCalculatorService(Trolley trolley);
    }
}
