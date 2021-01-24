using FluentAssertions;
using GoShopW.Model;
using GoShopW.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoShopW.Services.Tests
{
    public class SortServiceTests
    {
        [Theory]
        [InlineData(SortOption.Low, "Test Product D")]
        [InlineData(SortOption.High, "Test Product F")]
        [InlineData(SortOption.Ascending, "Test Product A")]
        [InlineData(SortOption.Descending, "Test Product F")]
        public async Task SortService_WithFakeDataFromJsonFile_GetSortedProducts_Success(SortOption sortOption, string expectedFirstProduct)
        {
            // Arrange 
            Mock<HttpMessageHandler> handlerMock = GetFakeHttpMessageHandler(GetFakeProducts());

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new System.Uri("http://Fake-url")
            };

            var httpFactory = new Mock<IHttpClientFactory>();
            httpFactory.Setup(h => h.CreateClient(HttpClients.ProductsClient))
                .Returns(httpClient);

            var sortService = new SortService(
                Mock.Of<ILogger<SortService>>(),
                httpFactory.Object
                );

            // Act
            var result = await sortService.GetSortedProducts(sortOption);

            // Assert
            result.Should().HaveCount(5);

            result.First().Name.Should().BeEquivalentTo(expectedFirstProduct);
        }



        [Fact]
        public async Task SortService_WithFakeDataFromJsonFile_SortProductsBy_Recommended()
        {
            // Arrange 
            var fakeProducts = JsonConvert.DeserializeObject<List<Product>>(GetFakeProducts());

            // Arrange 
            Mock<HttpMessageHandler> handlerMock = GetFakeHttpMessageHandler(GetFakeShopperHistory());

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new System.Uri("http://Fake-url")
            };

            var httpFactory = new Mock<IHttpClientFactory>();
            httpFactory.Setup(h => h.CreateClient(HttpClients.ShopperHistoryClient))
                .Returns(httpClient);

            var sortService = new SortService(
                Mock.Of<ILogger<SortService>>(),
                httpFactory.Object
                );

            // Act
            var result = await sortService.SortProductsBy(fakeProducts, SortOption.Recommended);

            // Assert 
            result.Should().NotBeNull();

            result.First().Name.Should().BeEquivalentTo("Test Product A");
        }

        private string GetFakeProducts()
        {
            using (StreamReader r = new StreamReader("products.json"))
            {
                return r.ReadToEnd();
            }
        }

        private string GetFakeShopperHistory()
        {
            using (StreamReader r = new StreamReader("shopperHistory.json"))
            {
                return r.ReadToEnd();
            }
        }

        private Mock<HttpMessageHandler> GetFakeHttpMessageHandler(string content)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(content),
               })
               .Verifiable();
            return handlerMock;
        }
    }
}
