namespace Driver;

public class Driver : Person
{
    public DateTime DateDriverLicense { get; set; } = default!;
    public Guid IdNumber { get; set; } = default!;
    public Vehicle Vehicle { get; set; } = null!;

    public void Print()
    {
        Console.WriteLine($"First name: {FirstName}\n" +
                          $"Last name: {LastName}\n" +
                          $"Date of Birth: {DateOfBirth.Date:d}\n" +
                          $"Date Driver License: {DateDriverLicense.Date:d}\n" +
                          $"Id number: {IdNumber}\n");
    }
}