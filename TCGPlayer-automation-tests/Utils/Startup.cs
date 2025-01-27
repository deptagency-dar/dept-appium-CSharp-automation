using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace TCGPlayer_automation_tests.Utils
{
    public static class Startup
    {
        private static IConfiguration ConfigurePlatform() =>
            new ConfigurationBuilder()
                
                //.AddJsonFile(@$"ConfigFiles\appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                .Build();

        public static string ReadFromAppSettings(string value) => ConfigurePlatform().GetSection(value).Value;
    }
}