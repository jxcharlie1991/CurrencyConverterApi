using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services;
using Xunit;

namespace CurrencyConverterApi.UnitTest.Services
{
    public class GetConversionRateServiceTests
    {
        private readonly IConfiguration _config;
        public GetConversionRateServiceTests()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config = configBuilder.Build();
        }
        [Fact]
        public async Task ExecuteAsync_Correct()
        {
            var response = new CurrencyConverterResponseModel()
            {
                Amount = TestData.ExchangeServiceAsync_GoodData.Amount,
                InputCurrency = TestData.ExchangeServiceAsync_GoodData.InputCurrency,
                OutputCurrency = TestData.ExchangeServiceAsync_GoodData.OutputCurrency,
            };
            var service = new GetConversionRateService(_config, response);

            await service.ExecuteAsync();

            Assert.NotNull(response.Value);
        }

        [Fact]
        public void FillInRequest_ValidRequest()
        {
            var response = new CurrencyConverterResponseModel();
            var service = new GetConversionRateService(_config, response);

            service.FillInRequest(TestData.ExchangeServiceAsync_GoodData);

            Assert.Equal(TestData.ExchangeServiceAsync_GoodData.Amount, response.Amount);
            Assert.Equal(TestData.ExchangeServiceAsync_GoodData.InputCurrency, response.InputCurrency);
            Assert.Equal(TestData.ExchangeServiceAsync_GoodData.OutputCurrency, response.OutputCurrency);
        }
    }
}