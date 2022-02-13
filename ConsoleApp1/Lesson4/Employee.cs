namespace Lesson4;

public class Employee: AbstractUser, IPrintable
{
    public Employee(Guid userId, string firstName, string lastName, string jobTittle, string jobDescription, 
        decimal jobSalary, string companyName, string companyCountry, string companyCity, string companyStreet) 
        : base(userId,firstName,lastName)
    {
        JobTittle = jobTittle;
        JobDescription = jobDescription;
        JobSalary = jobSalary;
        CompanyName = companyName;
        CompanyCountry = companyCountry;
        CompanyCity = companyCity;
        CompanyStreet = companyStreet;
    }

    public string JobTittle { get; set; }
    public string JobDescription { get; set; }
    public decimal JobSalary { get; set; }
    public string CompanyName { get; set; }
    public string CompanyCountry { get; set; }
    public string CompanyCity { get; set; }
    public string CompanyStreet { get; set; }
    
    public void Print()
    {
        Console.WriteLine($"Hello, I am {FirstName} {LastName}, {JobTittle} in {CompanyName} " +
                          $"({CompanyCountry}, {CompanyCity}, {CompanyStreet}) and my salary {JobSalary}");
    }
}