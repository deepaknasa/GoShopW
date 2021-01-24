using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Contracts
{
    public interface ITrolleyTotalCalculator
    {
        decimal GetTrolleyTotal(Trolley trolley);
    }
}
