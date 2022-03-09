namespace StoreSimulator;

public class Store
{
    private const string AlcoholCategory = "ALCOHOL";

    private const string ChoiceInfoString = "Choose user to view his cart (1-{0}): ";

    private readonly List<Customer> _buyers;

    public Store(List<Customer> buyers)
    {
        _buyers = buyers;
    }

    public void ShowMenu()
    {
        _buyers.ToList().ForEach(сustomer => сustomer.PrintCustomerInfo());
        Console.WriteLine("\n1. Choose user to view his cart. ");
        Console.WriteLine("2. Add new user. ");
        Console.WriteLine("3. Edit user's shopping cart ");
        Console.WriteLine("Any other key terminates program.");
    }

    public void ViewUserCart()
    {
        Console.WriteLine(ChoiceInfoString, _buyers.Count);
        var index = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Clear();
        _buyers[index - 1].CustomerCart.PrintShoppingCartSummary();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void AddNewUser()
    {
        Customer newUser;
        do
        {
            newUser = GetUserFromConsole();
            if (BuyerExists(newUser))
            {
                Console.WriteLine("\nERROR. This user already exists in system. Press any key to try again.");
                Console.ReadKey();
            }
            else
            {
                FillBuyerCart(newUser);
                Console.WriteLine("\nSuccess. Press any key to continue...");
                Console.ReadKey();
                break;
            }
        } while (true);
    }

    private static Customer GetUserFromConsole()
    {
        Console.Clear();
        Console.WriteLine("Enter new user info:\n");
        Console.Write("Name: ");
        var name = Validator.ValidateCustomerNameInput(Console.ReadLine());
        Console.Write("Surname: ");
        var surname = Validator.ValidateCustomerNameInput(Console.ReadLine());
        Console.Write("Age: ");
        var age = Validator.ValidateAge(Console.ReadLine());
        Console.Write("Passport: ");
        var passport = Validator.ValidatePassport(Console.ReadLine());
        return new Customer
        {
            Age = age,
            FirstName = name,
            LastName = surname,
            PassportId = passport
        };
    }


    public void EditUserCart()
    {
        Console.Write(ChoiceInfoString, _buyers.Count);
        var choice = int.Parse(Console.ReadLine() ?? string.Empty);
        var selectedUser = _buyers[choice - 1];
        Console.Clear();
        Console.WriteLine("Cart of this user:");
        selectedUser.CustomerCart.PrintShoppingCartSummary();
        Console.WriteLine("\n1. Add product.\n2. Delete product.");
        var action = Console.ReadLine();
        switch (action)
        {
            case "1":
            {
                AddProduct(selectedUser);
                break;
            }
            case "2":
            {
                RemoveProduct(selectedUser);
                break;
            }
            default:
            {
                return;
            }
        }
    }

    private static Goods? CreateProduct(Customer user)
    {
        do
        {
            if (!GetProductFromKeyboard(user, out var product))
            {
                continue;
            }
            return product;
        } while (true);
    }

    private static bool GetProductFromKeyboard(Customer user, out Goods? product)
    {
        Console.Write("\nEnter product name: ");
        var name = Console.ReadLine();
        Console.Write("Enter product category e.g. Meat, Fruit, Alcohol: ");
        var category = Console.ReadLine();
        if (!AlcoholAllowed(user, category))
        {
            product = null;
            return false;
        }
        Console.Write("Enter barcode: ");
        var barcode = Console.ReadLine();
        Console.Write("Enter price: ");
        var price = double.Parse(Console.ReadLine() ?? string.Empty);
        product = new Goods()
        {
            GoodsName = name,
            Category = category,
            BarcodeId = barcode,
            Price = price
        };
        return true;
    }

    private static bool AlcoholAllowed(Customer user, string? category)
    {
        if (user.Age >= 18 || !category!.ToUpper().Equals(AlcoholCategory))
        {
            return true;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ALCOHOL SELLING IS NOT ALLOWED FOR USERS UNDER 18!");
        Console.ReadKey();
        Console.ResetColor();
        return false;
    }

    private static void AddProduct(Customer selectedUser)
    {
        var newProduct = CreateProduct(selectedUser);
        selectedUser.CustomerCart.AddProduct(newProduct);
        Console.WriteLine("\nSuccess. Press any key to continue...");
        Console.ReadKey();
    }

    private static void RemoveProduct(Customer selectedUser)
    {
        Console.WriteLine("Choose product to remove: ");
        var selectedProduct = int.Parse(Console.ReadLine() ?? string.Empty);
        selectedUser.CustomerCart.RemoveProduct(selectedProduct);
        Console.WriteLine("\nSuccess. Press any key to continue...");
        Console.ReadKey();
    }

    private void FillBuyerCart(Customer newUser)
    {
        var productList = GoodsGenerator.GenerateProductsList(5);
        newUser.CustomerCart.AddProductsList(productList);
        _buyers.Add(newUser);
    }

    private bool BuyerExists(Customer newUser)
    {
        return _buyers.Any(buyer => buyer.Equals(newUser));
    }
}