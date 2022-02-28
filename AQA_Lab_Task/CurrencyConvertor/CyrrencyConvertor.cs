namespace CurrencyConvertor;

public static class CurrencyConvertor
{
    public static void ConvertFromTo(decimal amount, string? currency, string? currencyType)
    {
        decimal belRub = 0;
        decimal result = 0;
        double bankInterest = 0.97;

        if (currency != null)
            belRub = currency.ToUpper() switch
            {
                "USD" => amount * (decimal) Data.ExchangeRatesUsd,
                "EUR" => amount * (decimal) Data.ExchangeRatesEur,
                "RUB" => amount * (decimal) Data.ExchangeRatesRub,
                "BYN" => amount,
                _ => belRub
            };

        result = currencyType?.ToUpper() switch
        {
            "USD" => belRub / (decimal) Data.ExchangeRatesUsd * (decimal) bankInterest,
            "EUR" => belRub / (decimal) Data.ExchangeRatesEur * (decimal) bankInterest,
            "RUB" => belRub / (decimal) Data.ExchangeRatesRub * (decimal) bankInterest,
            "BYN" => belRub * (decimal) bankInterest,
            _ => result
        };

        Console.WriteLine($"{result:f2} {currencyType?.ToUpper()} с учетом комиссии банка в 3%");
    }
}