namespace CurrencyConvertor;

public static class ConsoleReader
{
    private static string? _initialData;
    private static string? _initialConversionСurrency;
    private static string? _exchangeAmount;
    private static Currency _currency;
    private static string? _initialCurrency;
    private static decimal _amount;
    private static Currency _conversionСurrency;

    public static decimal Amount => _amount;
    public static Currency СonversionСurrency => _conversionСurrency;
    public static Currency Currency => _currency;

    public static void Read()
    {
        while (true)
        {
            Console.WriteLine("Enter the amount indicating the source currency in the format USD/EUR/RUB/BYN.");
            _initialData = Console.ReadLine();
            Console.WriteLine("Enter the conversion currency in the format USD/EUR/RUB/BYN.");
            _initialConversionСurrency = Console.ReadLine();
            if (!string.IsNullOrEmpty(_initialData) && !string.IsNullOrEmpty(_initialConversionСurrency))
            {
                try
                {
                    var words = _initialData.Split(new[] {' '});
                    _exchangeAmount = words[0];
                    _initialCurrency = words[1];
                    _currency = (Currency) Enum.Parse(typeof(Currency), _initialCurrency, true);
                    _conversionСurrency = (Currency) Enum.Parse(typeof(Currency), _initialConversionСurrency, true);

                    if (decimal.TryParse(_exchangeAmount, out var number))
                    {
                        _amount = number;
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