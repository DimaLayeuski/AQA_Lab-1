using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Task20.Services;

public class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;
    public static string OnlinerUrl => Configuration[nameof(OnlinerUrl)];
    public static string VkComUrl => Configuration[nameof(VkComUrl)];
    public static string FacebookUrl => Configuration[nameof(FacebookUrl)];
    public static string TwitterUrl => Configuration[nameof(TwitterUrl)];
    public static string BrowserType => Configuration[nameof(BrowserType)];
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);
    public static string HerokuAppUrl => Configuration[nameof(HerokuAppUrl)];

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");
        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }
}