namespace Lesson4;

public class Candidate : IPrintable
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTittle { get; set; }
    public string? JobDescription { get; set; }
    public decimal JobSalary { get; set; }

    public void Print()
    {
        Console.WriteLine($"Hello, I am {FirstName} {LastName} I want to be a {JobTittle} " +
                          $"({JobDescription}) with a salary from {JobSalary}");
    }
    
}