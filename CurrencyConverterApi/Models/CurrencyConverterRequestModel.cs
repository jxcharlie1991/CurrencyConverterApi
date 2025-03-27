namespace CurrencyConverterApi.Models
{
    public class CurrencyConverterRequestModel
    {
        public double? Amount { get; set; }
        public string? InputCurrency { get; set; }
        public string? OutputCurrency { get; set; }
    }
}
