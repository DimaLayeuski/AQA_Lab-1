namespace Lesson4;

public class Candidate : IPrintToConsole
{
    public Candidate(decimal jobSalary, string? jobDescription, string? jobTittle, string? fullName, Guid userId)
    {
        JobSalary = jobSalary;
        JobDescription = jobDescription;
        JobTittle = jobTittle;
        FullName = fullName;
        UserId = userId;
    }

    public Guid UserId { get; set; }
    public string? FullName { get; set; }
    public string? JobTittle { get; set; }
    public string? JobDescription { get; set; }
    public decimal JobSalary { get; set; }

    public void PrintToConsole()
    {
        Console.WriteLine(
            $"Hello, I am {FullName} I want to be a {JobTittle} ({JobDescription}) with a salary from {JobSalary}");
    }
}