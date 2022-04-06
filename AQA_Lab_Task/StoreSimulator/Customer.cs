namespace StoreSimulator;

public class Customer
{
    private string _passportId;
    private string _firstName;
    private string _lastName;
    private int _age;
    private ShoppingCart _customerCart;

    public string PassportId
    {
        get => _passportId;
        set => _passportId = value;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public ShoppingCart CustomerCart
    {
        get => _customerCart;
        set => _customerCart = value;
    }

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