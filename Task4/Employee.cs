namespace Lesson4;

public class Employee:IPrintable
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTittle { get; set; }
    public string? JobDescription { get; set; }
    public decimal JobSalary { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyCountry { get; set; }
    public string? CompanyCity { get; set; }
    public string? CompanyStreet { get; set; }
    
    public void Print()
    {
        Console.WriteLine($"Hello, I am {FirstName} {LastName}, {JobTittle} in {CompanyName} " +
                          $"({CompanyCountry}, {CompanyCity}, {CompanyStreet}) and my salary {JobSalary}");
    }
}