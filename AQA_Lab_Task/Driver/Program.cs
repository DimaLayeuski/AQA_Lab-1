using Driver;

var driverGenerator = new DriverGenerator();
var drivers = driverGenerator.GenerateDrivers(3);
var vehicleGenerator = new VehicleGenerator(drivers);
var vehicles = vehicleGenerator.GenerateVehicles(3);

foreach (var driver in drivers)
{
    Console.WriteLine($"Driver {drivers.IndexOf(driver) + 1}");
    driver.Print();
}

string? command;
string? choice;
string? infoChoice;

do
{
    string commandTitle = "\nIf you want continue enter - 1 \nIf you want exit enter - 2 \n";
    command = StringUtils.StringConversion(commandTitle, 0, 3);
    if (command == "2")
    {
        break;
    }

    string mainTitle = "\nChoose driver (1-3): ";
    choice = StringUtils.StringConversion(mainTitle, 0, 5);

    var chosenDriver = drivers[int.Parse(choice!) - 1];
    var ownedVehicles = vehicles.Where(v => v.Owner != null && v.Owner.Equals(chosenDriver));

    string subtitle = "Select information you want to see:\n1.Vehicle specification.\n2.Driving statistics.\n";
    infoChoice = StringUtils.StringConversion(subtitle, 0, 3);

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
                    string title = $"Enter kilometers of {vehicle.Model}: ";
                    var input = StringUtils.StringConversion(title, 0, Int32.MaxValue);
                    var kilometers = int.Parse(input);
                    var fuelConsumption = vehicle.Engine.AverageConsumption * kilometers / 100;
                    var time = (double) kilometers / vehicle.Engine.MaximumSpeed;
                    var min = Math.Floor((time - Math.Floor(time)) * 60);
                    Console.WriteLine($"MaximumSpeed: {vehicle.Engine.MaximumSpeed}");
                    Console.WriteLine($"Fuel consumption for {vehicle.Model}: {fuelConsumption:F} l");
                    Console.WriteLine($"Drive time with max speed: {Math.Floor(time)} h {min} min\n");
                }
            }

            break;
        }
    }
} while (command != "2");