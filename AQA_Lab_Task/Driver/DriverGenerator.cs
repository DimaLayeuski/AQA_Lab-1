using Bogus;

namespace Driver;

public class DriverGenerator
{
    private readonly List<Driver> _drivers;

    public DriverGenerator()
    {
        _drivers = new List<Driver>();
    }

    public List<Driver> GenerateDrivers(short driverCount)
    {
        for (var i = 0; i < driverCount; i++)
        {
            var driver = new Faker<Driver>()
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth.Date)
                .RuleFor(x => x.IdNumber, _ => Guid.NewGuid())
                .RuleFor(x => x.IsDriver, x => x.Random.Bool())
                .RuleFor(x => x.DateDriverLicense,
                    x => x.Date.Between(x.Person.DateOfBirth.Date.AddYears(16), DateTime.Now))
                .Generate();
            _drivers.Add(driver);
        }

        return _drivers;
    }
}