using GoShopW.Contracts;
using GoShopW.Model;
using GoShopW.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoShopW.Services
{
    /// <inheritdoc cref="ISortService"/>
    public class SortService : ISortService
    {
        private readonly ILogger<SortService> _logger;
        private readonly IHttpClientFactory _factory;

        public SortService(
            ILogger<SortService> logger,
            IHttpClientFactory factory)
        {
            _factory = factory;
            _logger = logger;
        }

        /// <inheritdoc cref="ISortService.GetSortedProducts(SortOption)"/>
        public async Task<List<Product>> GetSortedProducts(SortOption sortOption)
        {
            var randomOrderProducts = await this.GetUnSortedProducts();

            return await this.SortProductsBy(randomOrderProducts, sortOption);
        }

        /// <inheritdoc cref="ISortService.SortProductsBy(IEnumerable{Product}, SortOption)"/>
        public async Task<List<Product>> SortProductsBy(IEnumerable<Product> products, SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                    return products.OrderBy(p => p.Price).ToList();
                case SortOption.High:
                    return products.OrderByDescending(p => p.Price).ToList();
                case SortOption.Ascending:
                    return products.OrderBy(p => p.Name).ToList();
                case SortOption.Descending:
                    return products.OrderByDescending(p => p.Name).ToList();
                case SortOption.Recommended:
                    return await this.GetRecommendedProducts(products);
                default:
                    throw new ArgumentException($"{nameof(sortOption)} - invalid sort option at this stage.");
            }
        }

        private async Task<List<Product>> GetRecommendedProducts(IEnumerable<Product> products)
        {
            using (var client = _factory.CreateClient(HttpClients.ShopperHistoryClient))
            {
                var shopperHistory = await client.GetAsync(string.Empty).ContinueWith((httpResponse) =>
                {
                    var response = httpResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<ShopHistory>>(jsonString.Result);
                });

                var allShoppedProducts = shopperHistory
                    .SelectMany(sh => sh.Products)
                    .ToList();

                allShoppedProducts
                    .AddRange(products);

                var productsBySaleQuantity = allShoppedProducts
                    .GroupBy(p => p.Name)
                    .ToDictionary(k => k.Key, v => v.Sum(s => s.Quantity));

                var sortedProductNames = productsBySaleQuantity.OrderByDescending(p => p.Value).Select(p => p.Key).ToList();

                return products.OrderBy(p => sortedProductNames.IndexOf(p.Name)).ToList();
            }
        }

        private async Task<List<Product>> GetUnSortedProducts()
        {
            using (var client = _factory.CreateClient(HttpClients.ProductsClient))
            {
                return await client.GetAsync(string.Empty).ContinueWith((httpResponse) =>
                {
                    var response = httpResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonString.Result).ToList();
                });
            }
        }
    }
}
