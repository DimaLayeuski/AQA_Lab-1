using SimpleLogger;
using Task6.Enums;
using Task6.Models;

namespace Task6.Services;

public static class InfoPrinter
{
    public static void PrintShopsInfo(List<Shop>? shops)
    {
        shops!.ForEach(shop =>
        {
            PrintShopInfo(shop);
            shop.Phones!.ForEach(PrintPhoneInfo);
            var iosCount = CountByOsType(OperatingSystemType.IOS, shop.Phones);
            var androidCount = CountByOsType(OperatingSystemType.ANDROID, shop.Phones);
            Logger.Log($"\n IOS phones: {iosCount} \n Android phones: {androidCount}");
        });
    }

    public static void PrintShopInfo(Shop shop)
    {
        Logger.Log($"Shop Id: {shop.Id} ||Shop Name: {shop.Name} ||Shop Description: {shop.Description}");
    }

    public static void PrintPhoneInfo(Phone? phone)
    {
        Logger.Log($"{phone!.Model} || {phone.OperatingSystemType.ToString()} || {phone.MarketLaunchDate}" +
                   $" || {phone.Price} || Available: {phone.IsAvailable}");
    }

    private static int CountByOsType(OperatingSystemType osType, IEnumerable<Phone?> phones)
    {
        var availablePhones = phones
            .Where(phone => phone!.OperatingSystemType.Equals(osType) && phone.IsAvailable);
        return availablePhones.Count();
    }
}
