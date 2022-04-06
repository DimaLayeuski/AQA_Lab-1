using StoreSimulator;

var users = CustomerGenerator.GenerateCustomerList(5);
var userCart = CustomerGenerator.GenerateCustomerCart(users, 5);
var shop = new Store(userCart);

string choice;
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