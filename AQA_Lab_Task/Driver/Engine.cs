namespace Driver;

public class Engine
{
    private double _capacity;
    private int _power;
    private FuelTypes _fuelType;
    private int _maximumSpeed;
    private double _averageConsumption;

    public double Capacity
    {
        get => _capacity;
        set => _capacity = value;
    }

    public int Power
    {
        get => _power;
        set => _power = value;
    }

    public FuelTypes FuelType
    {
        get => _fuelType;
        set => _fuelType = value;
    }

    public int MaximumSpeed
    {
        get => _maximumSpeed;
        set => _maximumSpeed = value;
    }

    public double AverageConsumption
    {
        get => _averageConsumption;
        set => _averageConsumption = value;
    }

    public void PrintEngine()
    {
        Console.WriteLine($"Capacity: {Capacity:N1}\n" +
                          $"Power: {Power}\n" +
                          $"FuelType: {FuelType}\n" +
                          $"MaximumSpeed: {MaximumSpeed}\n");
    }
}