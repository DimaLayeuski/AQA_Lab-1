using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Task6.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> SConfiguration;
        private static IConfiguration Configuration => SConfiguration.Value;

        public static string LogLevel => Configuration[nameof(LogLevel)];

        static Configurator()
        {
            SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath!, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}