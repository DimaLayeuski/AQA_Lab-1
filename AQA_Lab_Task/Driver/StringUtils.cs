namespace Driver;

public class StringUtils
{
    public static string StringConversion(string? description, int min, int max)
    {
        string? choice;
        while (true)
        {
            Console.Write(description);
            choice = Console.ReadLine();
            if (int.TryParse(choice, out var number) && number > min && number < max)
            {
                choice = number.ToString();
                break;
            }
            else
            {
                Console.WriteLine($"Enter the correct data, try again.\n");
            }
        }
        return choice;
    }
}