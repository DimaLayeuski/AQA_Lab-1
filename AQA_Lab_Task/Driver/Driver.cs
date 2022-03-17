namespace Driver;

public class Driver : Person
{
    private DateTime _dateDriverLicense;
    private Guid _idNumber;
    private Vehicle? _vehicle;

    public DateTime DateDriverLicense
    {
        get => _dateDriverLicense;
        set => _dateDriverLicense = value;
    }

    public Guid IdNumber
    {
        get => _idNumber;
        set => _idNumber = value;
    }

    public Vehicle? Vehicle
    {
        get => _vehicle;
        set => _vehicle = value;
    }

    public void Print()
    {
        Console.WriteLine($"First name: {FirstName}\n" +
                          $"Last name: {LastName}\n" +
                          $"Date of Birth: {DateOfBirth.Date:d}\n" +
                          $"Date Driver License: {DateDriverLicense.Date:d}\n" +
                          $"Id number: {IdNumber}\n");
    }
}