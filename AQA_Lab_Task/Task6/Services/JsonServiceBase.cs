using System.Reflection;

namespace Task6.Services;

public class JsonServiceBase
{
    protected static readonly string BasePath;

    static JsonServiceBase()
    {
        BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
