namespace CurrencyConvertor;

public static class Program
{
    static void Main()
    {
        ConsoleReader.Read();
        CurrencyConvertor.ConvertFromTo(ConsoleReader.Amount, ConsoleReader.Currency, ConsoleReader.СonversionСurrency);
    }
}