namespace CurrencyConverterApi.Models
{
    public class CurrencyConverterResponseModel
    {
        public double? Amount { get; set; }
        public string? InputCurrency { get; set; }
        public string? OutputCurrency { get; set; }
        public double? Value { get; set; }
    }
}
