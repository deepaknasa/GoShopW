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

        private static string GetTokenFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(UserInfoOptions.UserInfo).Get<UserInfoOptions>().Token;
        }

        private static string GetBaseUrlFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(ExternalEndpointOptions.ExternalEndpoint).Get<ExternalEndpointOptions>().BaseUrl;
        }
    }
}
