using GoShopW.Model;
using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoShopW.Contracts
{
    public interface ISortService
    {
        Task<List<Product>> GetSortedProducts(SortOption sortOption);
        Task<List<Product>> SortProductsBy(IEnumerable<Product> products, SortOption sortOption);
    }
}
