using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace TCGPlayer_automation_tests.Utils
{
    public static class Config
    {
        private static IConfiguration ConfigurePlatform(string path) =>
            new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();

        public static string ReadFromAppSettings(string value)
        {
            string platform = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower();
            if (platform == null)
            {
                platform = ReadFromGlobalConfig("default.platform");
            }
            
            return ConfigurePlatform(@$"ConfigFiles/appsettings.{platform}.json").GetSection(value).Value;
        } 
        
        public static string ReadFromGlobalConfig(string value) => ConfigurePlatform(@$"ConfigFiles/global.config.json").GetSection(value).Value;
    }
}