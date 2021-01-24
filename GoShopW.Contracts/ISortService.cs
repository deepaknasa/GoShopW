using GoShopW.Model;
using GoShopW.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoShopW.Contracts
{
    /// <summary>
    /// Service class which implements product sorting logic.
    /// </summary>
    public interface ISortService
    {
        /// <summary>
        /// Main method to get sorted products based on <paramref name="sortOption"/>.
        /// </summary>
        /// <param name="sortOption">Enumeration to dictate sort order.</param>
        /// <returns>A task which will yeild products in sorted order.</returns>
        Task<List<Product>> GetSortedProducts(SortOption sortOption);

        /// <summary>
        /// Main method to get <paramref name="products"/> sorted by <paramref name="sortOption"/>.
        /// </summary>
        /// <param name="products">List of products to be sorted.</param>
        /// <param name="sortOption">Enumeration to dictate sort order.</param>
        /// <returns>A task which will yeild products in sorted order.</returns>
        Task<List<Product>> SortProductsBy(IEnumerable<Product> products, SortOption sortOption);
    }
}
