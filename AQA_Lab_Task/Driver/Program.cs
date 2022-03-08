using Driver;

var driverGenerator = new DriverGenerator();
var drivers = driverGenerator.GenerateDrivers();
var vehicleGenerator = new VehicleGenerator(drivers);
var vehicles = vehicleGenerator.GenerateVehicles();

foreach (var driver in drivers)
{
    Console.WriteLine($"Driver {drivers.IndexOf(driver) + 1}");
    driver.Print();
}


Console.Write("\nChoose driver (1-3): ");
var choice = Console.ReadLine();
var chosenDriver = drivers[int.Parse(choice!) - 1];
var ownedVehicles = vehicles.Where(v => v.Owner != null && v.Owner.Equals(chosenDriver));
Console.WriteLine("Select information you want to see:\n1.Vehicle specification.\n2.Driving statistics.\n");
var infoChoice = Console.ReadLine();
switch (infoChoice)
{
    case "1":
    {
        foreach (var vehicle in ownedVehicles)
        {
            vehicle.PrintVehicle();
        }

        break;
    }

    case "2":
    {
        var drivingExperience = DateTime.Today.Year - chosenDriver.DateDriverLicense.Year;
        Console.WriteLine($"Driving experience is {drivingExperience}");
        foreach (var vehicle in ownedVehicles)
        {
            {
                Console.Write($"Enter mileage of {vehicle.Model}: ");
                var mileage = int.Parse(Console.ReadLine() ?? string.Empty);
                var fuelConsumption = vehicle.Engine.AverageConsumption * mileage / 100;
                var time = mileage / vehicle.Engine.MaximumSpeed;
                Console.WriteLine($"Fuel consumption for {vehicle.Model}: {fuelConsumption:F} l");
                Console.WriteLine($"Drive time with max speed: {time} h\n");
            }
        }

        break;
    }
}