using Newtonsoft.Json;
using SimpleLogger;

namespace Task6.Services;

public class JsonWriterService : JsonServiceBase
{
    public static void SerializeToFile<T>(string filename, T objectToWrite)
    {
        var fullPath = $"{BasePath}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}{filename}";
        string jsonString;
        try
        {
            jsonString = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
            File.WriteAllText(fullPath, jsonString);
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
    }
}
