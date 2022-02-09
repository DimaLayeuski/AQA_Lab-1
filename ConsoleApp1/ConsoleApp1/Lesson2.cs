namespace ConsoleApp1;

public static class Lesson2
{
    public static void Main(string[] args)
    {
        ChatBot.Chatting();
        
        Console.WriteLine("Введите сумму с указанием исходной валюты в формате USD/EUR/RUB/BYN.");
        string? text = Console.ReadLine();
        Console.WriteLine("Введите валюту конвертации в формате USD/EUR/RUB/BYN.");
        string? text2 = Console.ReadLine();
        Converter.ConvertFromTo(text,text2);
    }
}