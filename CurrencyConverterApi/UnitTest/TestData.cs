using CurrencyConverterApi.Models;

public static class TestData
{
    public static CurrencyConverterRequestModel ExchangeServiceAsync_GoodData { get; } = new CurrencyConverterRequestModel
    {
        Amount = 10,
        InputCurrency = "AUD",
        OutputCurrency = "USD"
    };

    public static IEnumerable<object[]> ExchangeServiceAsync_BadData { get; } = new List<object[]>
    {
        new object[] { new CurrencyConverterRequestModel { Amount = 10, InputCurrency = "AUX", OutputCurrency = "USD" } },
        new object[] { new CurrencyConverterRequestModel { Amount = null, InputCurrency = "AUD", OutputCurrency = "USD" } },
        new object[] { new CurrencyConverterRequestModel { Amount = null, InputCurrency = null, OutputCurrency = null } },
        new object[] { new CurrencyConverterRequestModel { Amount = 10, InputCurrency = "AUD", OutputCurrency = null } },
        new object[] { new CurrencyConverterRequestModel { Amount = 10, InputCurrency = null, OutputCurrency = "USD" } }
    };
}