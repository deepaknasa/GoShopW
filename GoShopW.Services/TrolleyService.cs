using GoShopW.Contracts;
using GoShopW.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoShopW.Services
{
    public class TrolleyService : ITrolleyService
    {
        private readonly ILogger<TrolleyService> _logger;
        private readonly IHttpClientFactory _factory;
        private readonly ITrolleyTotalCalculator _trolleyTotalCalculator;

        public TrolleyService(
            ILogger<TrolleyService> logger,
            IHttpClientFactory factory,
            ITrolleyTotalCalculator trolleyTotalCalculator)
        {
            _factory = factory;
            _logger = logger;
            _trolleyTotalCalculator = trolleyTotalCalculator;
        }

        public string HttpCients { get; }

        public async Task<decimal> GetTrolleyTotal(Trolley trolley)
        {
            var trolleyTotal = 0.0m;

            using (var client = _factory.CreateClient(HttpClients.TrolleyCalculatorClient))
            {
                var content = new StringContent(JsonConvert.SerializeObject(trolley), Encoding.UTF8, "application/json");

                await client.PostAsync(string.Empty, content)
                    .ContinueWith((httpResponse) =>
                    {
                        var response = httpResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(jsonString.Result))
                        {
                            trolleyTotal = JsonConvert.DeserializeObject<decimal>(jsonString.Result);
                        }
                    });

                return trolleyTotal;
            }
        }

        public async Task<decimal> GetTrolleyTotalWithCalculatorService(Trolley trolley)
        {
            // Note: No need to make it async. However to keep it consistent it above method which makes call to external endpoint
            // it becomes bit messy to add/remove async/await keywords while testing both endpoints.
            return await Task.FromResult(_trolleyTotalCalculator.GetTrolleyTotal(trolley));
        }
    }
}
