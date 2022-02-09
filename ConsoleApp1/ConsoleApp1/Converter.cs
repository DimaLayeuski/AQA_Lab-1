namespace ConsoleApp1;

public static class Converter
{
    public static void ConvertFromTo(string? originalAmount, string? currencyType)
    {
        var words = originalAmount?.Split(new[] {' '});
        if (words == null) return;
        decimal number = Convert.ToDecimal(words[0]);
        var currency = words[1];
        var exchangeRatesUsd = 2.5682;
        var exchangeRatesEur = 2.9356;
        var exchangeRatesRub = 0.033945;
        string usd = "USD";
        string eur = "EUR";
        string rub = "RUB";
        string byn = "BYN";
        decimal belRub = 0;

        if (currency.ToUpper().Equals(usd)) belRub = number * (decimal) exchangeRatesUsd;
        else if (currency.ToUpper().Equals(eur)) belRub = number * (decimal) exchangeRatesEur;
        else if (currency.ToUpper().Equals(rub)) belRub = number * (decimal) exchangeRatesRub;
        else if (currency.ToUpper().Equals(byn)) belRub = number;
        else Console.WriteLine("Данные введены неправильно");

        decimal result = 0;
        if (currencyType?.ToUpper() == usd) result = belRub / (decimal) exchangeRatesUsd * (decimal) 0.97;
        else if (currencyType?.ToUpper() == eur) result = belRub / (decimal) exchangeRatesEur * (decimal) 0.97;
        else if (currencyType?.ToUpper() == rub) result = belRub / (decimal) exchangeRatesRub * (decimal) 0.97;
        else if (currencyType?.ToUpper() == byn) result = belRub * (decimal) 0.97;
        else Console.WriteLine("Данные введены неправильно");

        Console.WriteLine($"{result:f2} {currencyType} с учетом комиссии банка в 3%");
    }
}