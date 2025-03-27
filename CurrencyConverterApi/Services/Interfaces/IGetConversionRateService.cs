using CurrencyConverterApi.Models;

namespace CurrencyConverterApi.Services.Interfaces
{
    public interface IGetConversionRateService
    {
        public CurrencyConverterResponseModel Response { get; set; }
        public ERConversionRateModel? ConversionRate { get; set; }
        public ERModel? ER { get; set; }

        public Task FillInRequest(CurrencyConverterRequestModel request);
        public Task ExecuteAsync();
    }
}
