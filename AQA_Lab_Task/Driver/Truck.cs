namespace Driver;

public class Truck : Vehicle
{
    public bool HasPricep { get; set; }

    public Truck(int year, string model, Engine engine, Driver? person) : base(year, model, engine)
    {
        Owner = person;
    }
}