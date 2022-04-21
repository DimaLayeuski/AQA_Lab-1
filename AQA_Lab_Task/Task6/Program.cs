using Task6.Data;
using Task6.Models;
using Task6.Services;

MenuHandler.AddHandler();

var shops = JsonReaderService.DeserializeFromFile<ShopsObject>(FileNames.DATA_FILE_NAME);
var menu = new MenuHandler(shops.Shops);

InfoPrinter.PrintShopsInfo(shops.Shops);
var phone = menu.ProcessUserInput();
menu.ProcessCheckout(phone, FileNames.OUTPUT_FILE_NAME);

Console.ReadKey();