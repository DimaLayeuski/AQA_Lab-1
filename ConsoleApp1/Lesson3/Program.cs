using Lesson3;

var driverGenerator = new DriverGenerator();
var drivers = driverGenerator.GenerateDrivers();

foreach (var driver in drivers)
{
    Console.WriteLine($"Driver {drivers.IndexOf(driver)+1}");
    driver.Print();
}