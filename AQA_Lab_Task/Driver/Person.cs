namespace Driver;

public class Person
{
    private string? _firstName;
    private string? _lastName;
    private DateTime _dateOfBirth;
    private bool _isDriver;

    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string? LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set => _dateOfBirth = value;
    }

    public bool IsDriver
    {
        get => _isDriver;
        set => _isDriver = value;
    }
}