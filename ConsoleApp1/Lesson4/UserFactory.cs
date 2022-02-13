using System.ComponentModel;
using Bogus;

namespace Lesson4;

public class UserFactory
{
    private const int MinSalary = 1000;
    private const int MaxSalary = 5000;
    public static IPrintable Generate(UserType userType)
    {
        switch (userType)
        {
            case UserType.Candidate:
                return GenerateCandidate();
            case UserType.Employee:
                return GenerateEmployee();
            default:
                throw new InvalidEnumArgumentException("Unknown user type" + userType);
        }
    }


    internal static Candidate GenerateCandidate()
    {
        return new Faker<Candidate>()
            .RuleFor(x => x.UserId, _ => Guid.NewGuid())
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.JobTittle, x => x.Name.JobTitle())
            .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
            .RuleFor(x => x.JobSalary, _ => new Random().Next(MinSalary, MaxSalary))
            .Generate();
    }

    internal static Employee GenerateEmployee()
    {
        return new Faker<Employee>()
            .RuleFor(x => x.UserId, _ => Guid.NewGuid())
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.JobTittle, x => x.Name.JobTitle())
            .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
            .RuleFor(x => x.JobSalary, _ => new Random().Next(MinSalary, MaxSalary))
            .RuleFor(x => x.CompanyName, x => x.Company.CompanyName())
            .RuleFor(x => x.CompanyCountry, x => x.Address.Country())
            .RuleFor(x => x.CompanyCity, x => x.Address.City())
            .RuleFor(x => x.CompanyStreet, x => x.Address.StreetName())
            .Generate();
        
    }
}