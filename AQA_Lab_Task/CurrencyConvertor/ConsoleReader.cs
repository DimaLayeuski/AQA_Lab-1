namespace CurrencyConvertor;

public static class ConsoleReader
{
    private static string? _text;
    private static string? _text2;
    private static string? _amount;
    public static decimal Amount;
    public static string? Currency;
    public static string? СonversionСurrency;
    private static readonly string[] CurrencyNames = new[] {"USD", "EUR", "RUB", "BYN"};

    public static void Read()
    {
        while (true)
        {
            Console.WriteLine("Enter the amount indicating the source currency in the format USD/EUR/RUB/BYN.");
            _text = Console.ReadLine();
            Console.WriteLine("Enter the conversion currency in the format USD/EUR/RUB/BYN.");
            _text2 = Console.ReadLine();
            if (_text != null && _text2 != null)
            {
                try
                {
                    var words = _text.Split(new[] {' '});
                    _amount = words[0];
                    Currency = words[1];
                    СonversionСurrency = _text2;

                    if (decimal.TryParse(_amount, out decimal number) &
                        CurrencyNames.Contains(Currency.ToUpper()) &
                        CurrencyNames.Contains(СonversionСurrency.ToUpper()))
                    {
                        Amount = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Couldn't recognize the amount or currency, try again.\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("You have entered incorrect data, re-enter the data.");
                    Console.WriteLine(ex);
                    Console.WriteLine("-----------------------------------------------------------------------------");
                }
            }
        }
    }
}