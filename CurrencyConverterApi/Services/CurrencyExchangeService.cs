using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services.Interfaces;

namespace CurrencyConverterApi.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private readonly IGetConversionRateService _getConversionRateService;
        public CurrencyExchangeService(CurrencyConverterRequestModel request, IGetConversionRateService getConversionRateService)
        {
            Request = request;
            _getConversionRateService = getConversionRateService;
        }

        public CurrencyConverterRequestModel? Request { get; }
        public CurrencyConverterResponseModel? Response { get; set; }

        public async Task ExecuteAsync()
        {
            // no input
            if (Request == null)
            {
                throw new ArgumentNullException(nameof(Request));
            }
            // lack of parameters or no result, I will not extend this part in the time .
            // also needs to check InputCurrency and OutputCurrency is implemented or not here....
            if (Request.InputCurrency == null || Request.OutputCurrency == null || Request.Amount == null)
            {
                throw new NotImplementedException("I will not extend this part in the time");
            }

            await _getConversionRateService.FillInRequest(Request);
            await _getConversionRateService.ExecuteAsync();
            Response = _getConversionRateService.Response;
        }
    }
}
