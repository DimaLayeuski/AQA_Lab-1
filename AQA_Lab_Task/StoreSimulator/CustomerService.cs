namespace StoreSimulator;

public static class CustomerService
{
    public static void PrintCustomerInfo(this Customer customer)
    {
        Console.WriteLine($"{customer.FirstName} {customer.LastName} || {customer.Age} || {customer.PassportId}");
    }
}
