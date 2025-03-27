using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services;
using CurrencyConverterApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ILogger<CurrencyConverterController> _logger;
        private readonly IConfiguration _configuration;

        public CurrencyConverterController(ILogger<CurrencyConverterController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> ExchangeServiceAsync([FromBody] CurrencyConverterRequestModel request)
        {
            // I split the GetConversionRateService from CurrencyExchangeService, because it is interface isolation principle(SOLID)
            CurrencyConverterResponseModel response = new CurrencyConverterResponseModel();
            IGetConversionRateService getConversionRateService = new GetConversionRateService(_configuration, response);
            ICurrencyExchangeService currencyExchangeService = new CurrencyExchangeService(request, getConversionRateService);
            try
            {
                await currencyExchangeService.ExecuteAsync();
            }
            catch (Exception ex)
            {
                // There will be serveral errors here, I will not extend them this time, just use Exception to catch everything
                _logger.LogError("Source: " + ex.Source + "| Message: " + ex.Message + "| StackTrace: " + ex.StackTrace);
                return NotFound();
            }
            return Ok(currencyExchangeService.Response);

        }
    }
}
