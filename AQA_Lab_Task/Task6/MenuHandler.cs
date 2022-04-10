using SimpleLogger;
using Task6.Exceptions;
using Task6.Models;

namespace Task6.Services;

public class MenuHandler
{
    private readonly List<Shop> _shops;

    public MenuHandler(List<Shop> shops)
    {
        _shops = shops;
    }

    public Phone? ProcessUserInput()
    {
        string? phoneModel;
        do
        {
            try
            {
                Logger.Log("Please Enter phone model: ");
                phoneModel = Console.ReadLine();
                if (TryFindPhones(phoneModel, out var phone))
                {
                    return phone;
                }
            }
            catch (PhoneNotFoundException ex)
            {
                Logger.Log(ex);
            }
        } while (true);
    }

    private bool TryFindPhones(string? phoneModel, out Phone? foundPhone)
    {
        var availableShops = FindAvailableShops(phoneModel);

        if (availableShops.Count == 0)
        {
            throw new PhoneNotFoundException($"Phone {phoneModel} not found.");
        }

        Phone? tempPhone = null;
        availableShops.ForEach(shop =>
        {
            InfoPrinter.PrintShopInfo(shop);
            tempPhone = FindPhoneByModelName(phoneModel, shop);
            InfoPrinter.PrintPhoneInfo(tempPhone);
        });

        if (tempPhone!.IsAvailable)
        {
            foundPhone = tempPhone;
            return true;
        }

        foundPhone = null;
        Logger.Log("Phone is not available in stock.");
        return false;
    }

    private static Phone? FindPhoneByModelName(string? phoneModel, Shop shop)
    {
        return shop.Phones!.First(smartphone => smartphone!.Model.Equals(phoneModel));
    }

    private List<Shop> FindAvailableShops(string? phoneModel)
    {
        return _shops!.FindAll(shop => shop.Phones!.Exists(item => item!.Model.Equals(phoneModel)));
    }

    public void ProcessCheckout(Phone? phone, string? filename)
    {
        Shop? chosenShop;
        string? shopName = null;
        do
        {
            Logger.Log("Enter shop you want to buy from: ");
            try
            {
                chosenShop = GetShopFromKeyboard(shopName);
                Logger.Log($"Order for shop {chosenShop}: {phone!.Model} for {phone.Price} USD successfully created!");
                JsonWriterService.SerializeToFile(filename, phone);
                return;
            }
            catch (StoreNotFoundException ex)
            {
                Logger.Log(ex);
            }
        } while (true);
    }

    private Shop GetShopFromKeyboard(string? shopName)
    {
        Shop? chosenShop;
        shopName = Console.ReadLine();
        chosenShop = _shops!.FirstOrDefault(shop => shop.Name.Equals(shopName));
        if (chosenShop == null)
        {
            throw new StoreNotFoundException("Store not found.");
        }

        return chosenShop;
    }
}