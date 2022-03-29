using Bogus;

namespace StoreSimulator;

public class CustomerGenerator
{
    private const int MinAge = 18;
    private const int MaxAge = 65;
    private const int PassportIdFormat = 7;
    private static readonly Faker<Customer> UserFaker;

    static CustomerGenerator()
    {
        UserFaker = new Faker<Customer>()
            .RuleFor(user => user.Age, faker => faker.Random.Int(MinAge, MaxAge))
            .RuleFor(user => user.FirstName, faker => faker.Person.FirstName)
            .RuleFor(user => user.PassportId, faker => string.Join(string.Empty, faker.Random.Digits(PassportIdFormat)))
            .RuleFor(user => user.LastName, faker => faker.Person.LastName);
    }

    public static List<Customer> GenerateCustomerList(int count = 1)
    {
        var customers = UserFaker.Generate(count);
        return customers;
    }
}