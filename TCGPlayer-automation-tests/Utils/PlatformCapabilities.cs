using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace TCGPlayer_automation_tests.Utils
{
    public class PlatformCapabilities
    {
        AppiumOptions appiumOptions = new AppiumOptions();

        public AppiumOptions InitAndroidCapabilities()
        {
            lock (appiumOptions)
            {
               // appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, Startup.ReadFromAppSettings("App"));
                //appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
            }            
            return appiumOptions;
        }

        public AppiumOptions InitIOSCapabilities()
        {
            lock (appiumOptions)
            {
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, Startup.ReadFromAppSettings("PlatformName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.AutomationName, Startup.ReadFromAppSettings("AutomationName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.PlatformVersion, Startup.ReadFromAppSettings("PlatformVersion"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.DeviceName, Startup.ReadFromAppSettings("DeviceName"));
                appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.App, Startup.ReadFromAppSettings("App"));
            }               
            return appiumOptions;
        }
    }
}