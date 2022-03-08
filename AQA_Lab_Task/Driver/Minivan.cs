namespace Driver;

public class Minivan : Vehicle
{
    public int SeatsCount;

    public Minivan(int year, string model, Engine engine, Driver? person) : base(year, model, engine)
    {
        Owner = person;
    }
}