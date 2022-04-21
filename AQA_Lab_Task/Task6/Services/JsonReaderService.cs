using Newtonsoft.Json;
using SimpleLogger;

namespace Task6.Services;

public class JsonReaderService : JsonServiceBase
{
    public static T? DeserializeFromFile<T>(string fileName)
    {
        var fullPath = $"{BasePath}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}{fileName}";
        string jsonString;

        try
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException();
            }

            jsonString = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(jsonString)!;
        }
        catch (JsonSerializationException ex)
        {
            Logger.Log(ex);
        }
        catch (FileNotFoundException ex)
        {
            Logger.Log(ex);
        }
        catch (IOException ex)
        {
            Logger.Log(ex);
        }

        return default;
    }
}