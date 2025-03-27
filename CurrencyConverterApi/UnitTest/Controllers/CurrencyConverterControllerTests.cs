using CurrencyConverterApi.Controllers;
using CurrencyConverterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CurrencyConverterApi.Tests
{
    public class CurrencyConverterControllerTests
    {
        private readonly Mock<ILogger<CurrencyConverterController>> _loggerMock;
        private readonly IConfiguration _config;
        private readonly CurrencyConverterController _controller;

        public CurrencyConverterControllerTests()
        {
            _loggerMock = new Mock<ILogger<CurrencyConverterController>>();
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config = configBuilder.Build();
            _controller = new CurrencyConverterController(_loggerMock.Object, _config);
        }

        [Fact]
        public async Task ExchangeServiceAsync_Correct()
        {
            var result = await _controller.ExchangeServiceAsync(TestData.ExchangeServiceAsync_GoodData);

            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [MemberData(nameof(TestData.ExchangeServiceAsync_BadData), MemberType = typeof(TestData))]
        public async Task ExchangeServiceAsync_Bad(CurrencyConverterRequestModel badData)
        {
            var result = await _controller.ExchangeServiceAsync(badData);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}