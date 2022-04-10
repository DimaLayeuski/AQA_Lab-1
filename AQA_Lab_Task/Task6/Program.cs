using SimpleLogger;
using SimpleLogger.Logging.Handlers;
using Task6.Models;
using Task6.Services;

const string datafileName = "phonedata.json";

const string outputFileName = "checkout.json";

Logger.LoggerHandlerManager.AddHandler(new ConsoleLoggerHandler());
Logger.DefaultLevel = Configurator.LogLevel switch
{
    "Fine" => Logger.Level.Fine,
    "Debug" => Logger.Level.Debug,
    "Info" => Logger.Level.Info,
    "Error" => Logger.Level.Error,
    _ => Logger.Level.None
};

var shops = JsonReaderService.DeserializeFromFile<ShopsObject>(datafileName);

var menu = new MenuHandler(shops.Shops);

InfoPrinter.PrintShopsInfo(shops.Shops);
var phone = menu.ProcessUserInput();
menu.ProcessCheckout(phone, outputFileName);

Console.ReadKey();
