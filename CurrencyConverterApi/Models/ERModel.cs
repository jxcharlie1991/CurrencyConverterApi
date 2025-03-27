using System.Text.Json.Serialization;

namespace CurrencyConverterApi.Models
{
    // This class generated through the documentation, which defines the response class https://www.exchangerate-api.com/docs/c-sharp-currency-api
    // the document is using camel Case, but C# prefer to use pascal case, so use JsonPropertyName to convert them
    public class ERModel
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }

        [JsonPropertyName("base_code")]
        public string? BaseCode { get; set; }

        [JsonPropertyName("conversion_rates")]
        public ERConversionRateModel? ConversionRates { get; set; }

    }
}
