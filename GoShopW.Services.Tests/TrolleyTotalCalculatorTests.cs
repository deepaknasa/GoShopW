using FluentAssertions;
using GoShopW.Models;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace GoShopW.Services.Tests
{
    public class TrolleyTotalCalculatorTests
    {
        [Theory]
        [InlineData("trolley1.json", 14.0)]
        [InlineData("trolley2.json", 74.59066381545)]
        public void TrolleyTotalCalculator_GetTrolleyTotal(string fakeTrolleyJSONFilePath, decimal expectedTotal)
        {
            // Arrange
            var fakeTrolley = GetTrolley(fakeTrolleyJSONFilePath);
            var trolleyCalculator = new TrolleyTotalCalculator();

            // Act 
            var result = trolleyCalculator.GetTrolleyTotal(fakeTrolley);

            // Assert
            result.Should().BeApproximately(expectedTotal, 0.00000000001m);
        }

        private Trolley GetTrolley(string fakeTrolleyJSONPath)
        {
            using (var stream = new StreamReader(fakeTrolleyJSONPath))
            {
                var trolleyJSON = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<Trolley>(trolleyJSON);
            }
        }
    }
}
