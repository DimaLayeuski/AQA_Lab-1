using Bogus;

namespace Lesson3;

public class VehicleGenerator
{
    
    public  Engine GenerateEngine()
    {
        return new Faker<Engine>()
            .RuleFor(x => x.Capacity, x => x.Random.Double(1D,3D))
            .RuleFor(x => x.Power, x => x.Random.Int(100, 500))
            .RuleFor(x => x.FuelType, x => x.PickRandom<FuelTypes>())
            .RuleFor(x => x.MaximumSpeed, x => x.Random.Int(150,300))
            .Generate();
        }
   
    public static Vehicle GenerateVehicle(Driver owner, Engine engine)
    {
        return new Faker<Vehicle>()
            .RuleFor(x => x.Model, x => x.Vehicle.Manufacturer()+" "+x.Vehicle.Model())
            .RuleFor(x => x.Year, x => x.Date.Past(25).Year)
            .RuleFor(x => x.Owner, owner)
            .RuleFor(x => x.Engine, engine)
            .Generate();
    }
    
    }