namespace Driver;

public class Vehicle
{
    private readonly string? _model;
    private readonly int _year;
    private Driver? _owner;
    private readonly Engine _engine;

    public string? Model => _model;
    public Engine Engine => _engine;

    public Driver? Owner
    {
        get => _owner;
        set => _owner = value;
    }

    protected Vehicle(int year, string? model, Engine engine)
    {
        _year = year;
        _model = model;
        _engine = engine;
    }

    public void PrintVehicle()
    {
        Console.WriteLine($"Model: {Model}\n" +
                          $"Year: {_year:d}\n" +
                          $"Capacity: {Engine.Capacity:0.00}\n" +
                          $"Power: {Engine.Power}\n" +
                          $"FuelType: {Engine.FuelType}\n" +
                          $"MaximumSpeed: {Engine.MaximumSpeed}\n");
    }
}