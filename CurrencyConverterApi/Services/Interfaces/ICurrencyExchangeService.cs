using CurrencyConverterApi.Models;

namespace CurrencyConverterApi.Services.Interfaces
{
    public interface ICurrencyExchangeService
    {
        public CurrencyConverterRequestModel? Request { get; }
        public CurrencyConverterResponseModel? Response { get; set; }

        public Task ExecuteAsync();
    }
}
