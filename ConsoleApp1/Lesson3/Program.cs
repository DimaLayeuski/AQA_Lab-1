using Lesson3;

var driverGenerator = new DriverGenerator();
var drivers = driverGenerator.GenerateDrivers();

foreach (var driver in drivers)
{
    Console.WriteLine($"Driver {drivers.IndexOf(driver)+1}\n" +
                      $"First name: {driver.FirstName}\n" +
                      $"Last name: {driver.LastName}\n" +
                      $"Date of Birth: {driver.DateOfBirth.Date.ToString("d")}\n" +
                      $"Date Driver License: {driver.DateDriverLicense.Date.ToString("d")}\n" +
                      $"Id number: {driver.IdNumber}\n");
}