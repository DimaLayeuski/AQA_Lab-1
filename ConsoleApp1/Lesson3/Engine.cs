namespace Lesson3;

public class Engine
{
    public double Capacity { get; set; }
    public int Power { get; set; }
    public FuelTypes FuelType { get; set; }
    public int MaximumSpeed { get; set; }
    
    public void PrintEngine()
    {
        Console.WriteLine($"Capacity: {Capacity:N1}\n" +
                          $"Power: {Power}\n" +
                          $"FuelType: {FuelType}\n" +
                          $"MaximumSpeed: {MaximumSpeed}\n");
    }
}