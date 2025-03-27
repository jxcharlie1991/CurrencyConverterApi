using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services;
using CurrencyConverterApi.Services.Interfaces;
using Moq;
using Xunit;

namespace CurrencyConverterApi.Tests
{
    public class CurrencyExchangeServiceTests
    {
        [Fact]
        public async Task ExecuteAsync_Correct()
        {
            var mockRateService = new Mock<IGetConversionRateService>();
            mockRateService.Setup(x => x.Response).Returns(new CurrencyConverterResponseModel());

            var service = new CurrencyExchangeService(TestData.ExchangeServiceAsync_GoodData, mockRateService.Object);

            await service.ExecuteAsync();

            Assert.NotNull(service.Response);
        }

        [Fact]
        public async Task ExecuteAsync_NullRequest()
        {
            var mockRateService = new Mock<IGetConversionRateService>();
            var service = new CurrencyExchangeService(null, mockRateService.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(service.ExecuteAsync);
        }
    }
}