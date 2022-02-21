namespace Lesson3;

public class Vehicle
{
    public string? Model { get; set; }
    public int Year { get; set; }
    public Driver? Owner { get; set; }
    public Engine Engine { get; set; }
    
    
    public void PrintVehicle()
    {
        Console.WriteLine($"Model: {Model}\n" +
                          $"Year: {Year:d}\n"); 
                          // $"Capacity: {Engine.Capacity}\n"+
                          // $"Power: {Engine.Power}\n"+
                          // $"FuelType: {Engine.FuelType}\n"+
                          // $"MaximumSpeed: {Engine.MaximumSpeed}\n");
    }
}