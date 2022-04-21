using SimpleLogger;
using Task6.Enums;
using Task6.Models;

namespace Task6.Services;

public static class InfoPrinter
{
    public static void PrintShopsInfo(List<Shop> shops)
    {
        shops!.ForEach(shop =>
        {
            PrintShopInfo(shop);
            shop.Phones!.ForEach(PrintPhoneInfo);
            var iosCount = CountByOsType(OperationSystemType.IOS.ToString(), shop.Phones);
            var androidCount = CountByOsType(OperationSystemType.Android.ToString(), shop.Phones);
            Logger.Log($"\n IOS phones: {iosCount} \n Android phones: {androidCount}");
        });
    }

    public static void PrintShopInfo(Shop shop)
    {
        Logger.Log($"Shop Id: {shop.Id} ||Shop Name: {shop.Name} ||Shop Description: {shop.Description}");
    }

    public static void PrintPhoneInfo(Phone phone)
    {
        Logger.Log($"{phone!.Model} || {phone.OperationSystemType} || {phone.MarketLaunchDate}" +
                   $" || {phone.Price} || Available: {phone.IsAvailable}");
    }

    private static int CountByOsType(string osType, IEnumerable<Phone> phones)
    {
        var availablePhones = phones
            .Where(phone => phone!.OperationSystemType.Equals(osType) && phone.IsAvailable);
        return availablePhones.Count();
    }
}
