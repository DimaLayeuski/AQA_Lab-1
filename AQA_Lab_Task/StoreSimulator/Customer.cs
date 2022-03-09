namespace StoreSimulator;

public class Customer
{
    public string PassportId { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public int Age { get; init; }
    public ShoppingCart CustomerCart { get; }

    public Customer()
    {
        CustomerCart = new ShoppingCart();
    }

    public override bool Equals(object? obj)
    {
        var anotherUser = obj as Customer;
        return anotherUser!.PassportId.Equals(PassportId);
    }
    
    
    
}