namespace Driver;

public class SportCar : Vehicle
{
    public SportCar(int year, string model, Engine engine, Driver? person) : base(year, model, engine)
    {
        Owner = HasExperience(person) ? person : null;
    }

    private static bool HasExperience(Driver? person)
    {
        return DateTime.Today.Year - person!.DateDriverLicense.Year > 5;
    }
}