namespace Driver;

public class Minivan : Vehicle
{
    private int _seatsCount;

    public int SeatsCount
    {
        get => _seatsCount;
        set => _seatsCount = value;
    }

    public Minivan(int year, string model, Engine engine, Driver? person) : base(year, model, engine)
    {
        Owner = person;
    }
}