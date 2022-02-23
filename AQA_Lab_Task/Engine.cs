namespace Driver;

public class Engine
{
    public double Capacity { get; set; } = default!;
    public int Power { get; set; } = default!;
    public FuelTypes FuelType { get; set; } = default!;
    public int MaximumSpeed { get; set; } = default!;
    public double AverageConsumption { get; set; } = default!;

    public void PrintEngine()
    {
        Console.WriteLine($"Capacity: {Capacity:N1}\n" +
                          $"Power: {Power}\n" +
                          $"FuelType: {FuelType}\n" +
                          $"MaximumSpeed: {MaximumSpeed}\n");
    }
}