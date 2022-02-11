using Bogus;
using Lesson4;

Candidate CreateCandidate()
{
    var candidateFaker = new Faker<Candidate>()
        .RuleFor(x => x.UserId, x => Guid.NewGuid())
        .RuleFor(x => x.FullName, x => x.Person.FullName)
        .RuleFor(x => x.JobTittle, x => x.Name.JobTitle())
        .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
        .RuleFor(x => x.JobSalary, x => new Random().Next(1000, 5000));
    return candidateFaker.Generate();
}

Employee CreateEmployee()
{
    var employeeFaker = new Faker<Employee>()
        .RuleFor(x => x.UserId, x => Guid.NewGuid())
        .RuleFor(x => x.FullName, x => x.Person.FullName)
        .RuleFor(x => x.JobTittle, x => x.Name.JobTitle())
        .RuleFor(x => x.JobDescription, x => x.Name.JobDescriptor())
        .RuleFor(x => x.JobSalary, x => new Random().Next(1000, 5000))
        .RuleFor(x => x.CompanyName, x => x.Company.CompanyName())
        .RuleFor(x => x.CompanyCountry, x => x.Address.Country())
        .RuleFor(x => x.CompanyCity, x => x.Address.City())
        .RuleFor(x => x.CompanyStreet, x => x.Address.StreetName());
    return employeeFaker.Generate();
}
