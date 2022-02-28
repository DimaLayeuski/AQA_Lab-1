using System.Globalization;

namespace ConsoleApp1;

public class ChatBot
{
    public static void Chatting()
    {
        Console.WriteLine("Здравствуйте! Введите вашу Фамилию.");
        var lastName = Console.ReadLine();

        while (lastName != null && (char.IsLower(lastName[0]) || lastName.Any(char.IsDigit)))
        {
            Console.WriteLine("Введен неверный формат данных, введите вашу Фамилию повторно");
            lastName = Console.ReadLine();
        }

        Console.WriteLine("Введите ваше Имя.");
        var name = Console.ReadLine();
        while (name != null && (char.IsLower(name[0]) || name.Any(char.IsDigit)))
        {
            Console.WriteLine("Введен неверный формат данных, введите ваше Имя повторно");
            name = Console.ReadLine();
        }

        Console.WriteLine("Введите дату приема в формате дд/мм/гггг");
        var dateNow = DateTime.Now;
        var date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        while (date <= dateNow)
        {
            Console.WriteLine("Введена неверная дата, введите дату приема повторно в формате дд/мм/гггг");
            date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        }

        Random rnd = new Random();
        int value = rnd.Next(8, 19);

        Console.WriteLine($"{name} {lastName}, Вы записаны на прием " +
                          $"{date.AddHours(value).ToString("g", DateTimeFormatInfo.InvariantInfo)}.");
    }
}