namespace Lesson4;

public class Candidate : AbstractUser, IPrintable
{
    public Candidate(decimal jobSalary, string? jobDescription, string? jobTittle, Guid userId,
        string? lastName, string? firstName) : base(userId,firstName,lastName)
    {
        
        JobSalary = jobSalary;
        JobDescription = jobDescription;
        JobTittle = jobTittle;
    }

    public string? JobTittle { get; set; }
    public string? JobDescription { get; set; }
    public decimal JobSalary { get; set; }

    public void Print()
    {
        Console.WriteLine($"Hello, I am {FirstName} {LastName} I want to be a {JobTittle} " +
                          $"({JobDescription}) with a salary from {JobSalary}");
    }
    
}