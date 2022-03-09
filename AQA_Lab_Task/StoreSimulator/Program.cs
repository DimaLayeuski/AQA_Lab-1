using StoreSimulator;

var users = CustomerGenerator.GenerateCustomerList(5);
users.ToList().ForEach(user =>
{
    var products = GoodsGenerator.GenerateProductsList(5);
    user.CustomerCart.AddProductsList(products);
});
var shop = new Store(users);

string? choice;
do
{
    Console.Clear();
    shop.ShowMenu();
    choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
        {
            shop.ViewUserCart();
            break;
        }
        case "2":
        {
            shop.AddNewUser();
            break;
        }
        case "3":
        {
            shop.EditUserCart();
            break;
        }
        default:
        {
            choice = "";
            break;
        }
    }
} while (!string.IsNullOrEmpty(choice));