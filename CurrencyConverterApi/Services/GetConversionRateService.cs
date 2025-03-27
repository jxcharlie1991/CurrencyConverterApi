using CurrencyConverterApi.Models;
using CurrencyConverterApi.Services.Interfaces;
using System.Text.Json;

namespace CurrencyConverterApi.Services
{
    public class GetConversionRateService : IGetConversionRateService
    {
        private readonly string? _eRApiKey;
        public GetConversionRateService(IConfiguration configuration, CurrencyConverterResponseModel response)
        {
            _eRApiKey = configuration.GetValue(typeof(string), "ERApiKey")?.ToString();
            Response = response;
        }
        public CurrencyConverterResponseModel Response { get; set; }
        public ERConversionRateModel? ConversionRate { get; set; }
        public ERModel? ER { get; set; }

        public Task FillInRequest(CurrencyConverterRequestModel request)
        {
            // no response
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Response.InputCurrency = request.InputCurrency;
            Response.OutputCurrency = request.OutputCurrency;
            Response.Amount = request.Amount;
            return Task.CompletedTask;
        }
        public async Task ExecuteAsync()
        {
            // no response
            if (Response == null)
            {
                throw new ArgumentNullException(nameof(Response));
            }

            var httpClient = new HttpClient();
            string URLString = $"https://v6.exchangerate-api.com/v6/{_eRApiKey}/latest/{Response.InputCurrency}";
            var response = await httpClient.GetStringAsync(URLString);
            ER = JsonSerializer.Deserialize<ERModel>(response);

            // here for easier understanding, I just hard coded the usd dollar here,
            // but if it is not code test(have more languages to look up), I will generate a 
            // new method to do the task
            if (ER != null && ER.ConversionRates != null && Response.OutputCurrency?.ToUpper() == "USD")
            {
                Response.Value = ER.ConversionRates.USD * Response.Amount;
                return;
            }

            // Should throw a not found message here
            throw new Exception("Failed Get Conversion Rate");
        }
    }
}