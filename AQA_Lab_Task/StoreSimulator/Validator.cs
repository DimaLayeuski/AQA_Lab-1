using System.Text.RegularExpressions;
using static System.Console;

namespace StoreSimulator;

public class Validator
{
    private const string NamePattern = "^[A-Z][a-zA-Z]*";

    private const string PassportPattern = "[0-9]{7}";

    private const string AgePattern = "^[1-9][0-9]?$";

    public static string ValidateCustomerNameInput(string? name)
    {
        do
        {
            if (name != null && CheckRegex(name, NamePattern))
            {
                return name;
            }

            Write("\nYou have error in you input. Please input a valid name or surname:");
            name = ReadLine();
        } while (true);
    }

    public static int ValidateAge(string? age)
    {
        do
        {
            if (age != null && CheckRegex(age, AgePattern))
            {
                return int.Parse(age);
            }

            Write("\nYou have error in you input. Please input a valid age:");
            age = ReadLine();
        } while (true);
    }

    public static string ValidatePassport(string? passportId)
    {
        do
        {
            if (passportId != null && CheckRegex(passportId, PassportPattern))
            {
                return passportId;
            }

            Write("\nYou have error in you input. Please input a valid PID:");
            passportId = ReadLine();
        } while (true);
    }

    private static bool CheckRegex(string name, string pattern)
    {
        return Regex.Match(name, pattern).Success;
    }
}