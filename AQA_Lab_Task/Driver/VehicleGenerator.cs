using Bogus;

namespace Driver;

public class VehicleGenerator
{
    private readonly Faker _faker;
    private readonly List<Vehicle> _vehicles;
    private readonly List<Driver>? _drivers;
    private const int VehicleCount = 3;

    public VehicleGenerator(List<Driver> drivers)
    {
        _drivers = drivers;
        _faker = new Faker();
        _vehicles = new List<Vehicle>();
    }

    public IEnumerable<Vehicle> GenerateVehicles()
    {
        for (var i = 0; i < VehicleCount; i++)
        {
            _vehicles.Add(GenerateMinivan());
            _vehicles.Add(GenerateTruck());
            _vehicles.Add(GenerateSportCar());
        }

        return _vehicles;
    }

    private Truck GenerateTruck()
    {
        var truck = new Truck(
            _faker.Date.Past(10).Year,
            _faker.Vehicle.Model(),
            GenerateEngine(),
            _faker.PickRandom(_drivers))
        {
            HasPricep = _faker.Random.Bool()
        };
        return truck;
    }

    private SportCar GenerateSportCar()
    {
        var sportCar = new SportCar(
            _faker.Date.Past(10).Year,
            _faker.Vehicle.Model(),
            GenerateEngine(),
            _faker.PickRandom(_drivers));
        return sportCar;
    }

    private Minivan GenerateMinivan()

    {
        var van = new Minivan(
            _faker.Date.Past(10).Year,
            _faker.Vehicle.Model(),
            GenerateEngine(),
            _faker.PickRandom(_drivers))
        {
            SeatsCount = _faker.Random.Int(3, 8)
        };
        return van;
    }

    private Engine GenerateEngine()
    {
        return new Faker<Engine>()
            .RuleFor(x => x.Capacity, x => x.Random.Double(1D, 3D))
            .RuleFor(x => x.Power, x => x.Random.Int(100, 500))
            .RuleFor(x => x.FuelType, x => x.PickRandom<FuelTypes>())
            .RuleFor(x => x.MaximumSpeed, x => x.Random.Int(150, 300))
            .RuleFor(x => x.AverageConsumption, x => x.Random.Int(7, 20))
            .Generate();
    }
}