using Bogus;

namespace Lesson3;

public class DriverGenerator
{
    private const short DriverCount = 3;
    private readonly Faker _faker;
    private readonly List<Driver> _drivers;

    public DriverGenerator()
    {
        _drivers = new List<Driver>();
        _faker = new Faker();
    }

    public List<Driver> GenerateDrivers()
    {
        for (var i = 0; i < DriverCount; i++)
        {
            var driver = new Faker<Driver>()
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth.Date)
                .RuleFor(x => x.IdNumber, _ => Guid.NewGuid())
                .RuleFor(x => x.IsDriver, x => x.Random.Bool())
                .RuleFor(x => x.IsDriver, x => x.Random.Bool())
                .Generate();
            driver.DateDriverLicense = _faker.Date.Between(driver.DateOfBirth.AddYears(16), DateTime.Now);
            _drivers.Add(driver);
        }

        return _drivers;
    }
}