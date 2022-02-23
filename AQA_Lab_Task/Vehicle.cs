namespace Driver;

public class Vehicle
{
    public string? Model { get; set; }
    private int Year { get; set; }
    public Driver? Owner { get; set; }
    public Engine Engine { get; set; }

    protected Vehicle(int year, string? model, Engine engine)
    {
        Year = year;
        Model = model;
        Engine = engine;
    }

    public void PrintVehicle()
    {
        Console.WriteLine($"Model: {Model}\n" +
                          $"Year: {Year:d}\n" +
                          $"Capacity: {Engine.Capacity:0.00}\n" +
                          $"Power: {Engine.Power}\n" +
                          $"FuelType: {Engine.FuelType}\n" +
                          $"MaximumSpeed: {Engine.MaximumSpeed}\n");
    }
}