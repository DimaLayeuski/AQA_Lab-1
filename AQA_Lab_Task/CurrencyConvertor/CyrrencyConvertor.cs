namespace CurrencyConvertor;

public static class CurrencyConvertor
{
    public static void ConvertFromTo(decimal amount, Currency currency, Currency currencyType)
    {
        decimal belRub = 0;
        decimal result = 0;
        double bankInterest = 0.97;

        belRub = currency switch
        {
            Currency.Usd => amount * (decimal) Data.ExchangeRatesUsd,
            Currency.Eur => amount * (decimal) Data.ExchangeRatesEur,
            Currency.Rub => amount * (decimal) Data.ExchangeRatesRub,
            Currency.Byn => amount,
            _ => belRub
        };

        result = currencyType switch
        {
            Currency.Usd => belRub / (decimal) Data.ExchangeRatesUsd * (decimal) bankInterest,
            Currency.Eur => belRub / (decimal) Data.ExchangeRatesEur * (decimal) bankInterest,
            Currency.Rub => belRub / (decimal) Data.ExchangeRatesRub * (decimal) bankInterest,
            Currency.Byn => belRub * (decimal) bankInterest,
            _ => result
        };

        Console.WriteLine($"{result:f2} {currencyType} с учетом комиссии банка в 3%");
    }
}