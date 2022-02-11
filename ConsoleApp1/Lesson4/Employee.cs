namespace Lesson4;

public class Employee:IPrintToConsole
{
    public Employee(Guid userId, string fullName, string jobTittle, string jobDescription, decimal jobSalary, string companyName, string companyCountry, string companyCity, string companyStreet)
    {
        UserId = userId;
        FullName = fullName;
        JobTittle = jobTittle;
        JobDescription = jobDescription;
        JobSalary = jobSalary;
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyCity = companyCity;
        CompanyStreet = companyStreet;
    }

    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string JobTittle { get; set; }
    public string JobDescription { get; set; }
    public decimal JobSalary { get; set; }
    public string CompanyName { get; set; }
    public string CompanyCountry { get; set; }
    public string CompanyCity { get; set; }
    public string CompanyStreet { get; set; }
    
    public void PrintToConsole()
    {
        Console.WriteLine($"Hello, I am {FullName}, {JobTittle} in {CompanyName} " +
                          $"({CompanyCountry}, {CompanyCity}, {CompanyStreet}) and my salary {JobSalary}");
    }
}