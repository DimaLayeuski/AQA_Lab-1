using System.Globalization;

namespace DoctorAppointment;

public static class DoctorAppointment
{
    private static int _timeOpen = 8;
    private static int _timeClose = 19;

    public static void Chatting()
    {
        Console.WriteLine("Hello! Enter your Last Name.");
        var lastName = Console.ReadLine();
        var refactorLastName = StringUtils.StringConversion(lastName);

        Console.WriteLine("Enter your Name.");
        var name = Console.ReadLine();
        var refactorName = StringUtils.StringConversion(name);

        Console.WriteLine("Enter the appointment date in the format dd/mm/yyyy");
        var dateNow = DateTime.Now;
        var date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        while (date <= dateNow)
        {
            Console.WriteLine("Invalid date entered, please re-enter the appointment date in the format dd/mm/yyyy");
            date = DateTime.Parse(Console.ReadLine() ?? string.Empty);
        }

        Random rnd = new Random();
        int workTime = rnd.Next(_timeOpen, _timeClose);

        Console.WriteLine($"{refactorName} {refactorLastName}, You have an appointment on " +
                          $"{date.AddHours(workTime).ToString("g", DateTimeFormatInfo.InvariantInfo)}.");
    }
}