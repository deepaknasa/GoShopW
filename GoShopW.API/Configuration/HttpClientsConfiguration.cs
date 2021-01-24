using GoShopW.Models.Configuration;
using GoShopW.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopW.API.Configuration
{
    /// <summary>
    /// Extension class to add named http clients required for this app.
    /// </summary>
    public static class HttpClientsConfiguration
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var token = GetTokenFromConfiguration(configuration);

            var baseUrl = GetBaseUrlFromConfiguration(configuration);

            services
                .AddHttpClient(HttpClients.ProductsClient, configureClient =>
                {
                    configureClient.BaseAddress = new Uri($"{baseUrl}/products?token={token}");
                });

            services
                .AddHttpClient(HttpClients.ShopperHistoryClient, configureClient =>
                {
                    configureClient.BaseAddress = new Uri($"{baseUrl}/shopperHistory?token={token}");
                });
            
            services
                .AddHttpClient(HttpClients.TrolleyCalculatorClient, configureClient =>
                {
                    configureClient.BaseAddress = new Uri($"{baseUrl}/trolleyCalculator?token={token}");
                });
        }

        /// <summary>
        /// Since extension methods are being called from ConfigureServices and DI container hasn't yet initialised, using 
        /// GetSection method of IConfiguration to read config values.
        /// </summary>
        /// <param name="configuration">Configuration object which consolidate config values from multiple providers.</param>
        /// <returns>Token from config file. It will most likely be stored in cloud configuration or app-secrets.</returns>
        private static string GetTokenFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(UserInfoOptions.UserInfo).Get<UserInfoOptions>().Token;
        }

        /// <summary>
        /// Since extension methods are being called from ConfigureServices and DI container hasn't yet initialised, using 
        /// GetSection method of IConfiguration to read config values.
        /// </summary>
        /// <param name="configuration">Configuration object which consolidate config values from multiple providers.</param>
        /// <returns>Base url to access external endpoints.</returns>
        private static string GetBaseUrlFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(ExternalEndpointOptions.ExternalEndpoint).Get<ExternalEndpointOptions>().BaseUrl;
        }
    }
}
