using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;

namespace TCGPlayer_automation_tests.Utils;

public abstract class DeviceOptions
{ 
    public static readonly DeviceOptions ANDROID = new AndroidOptions();
    public static readonly DeviceOptions IOS = new IOSOptions();
    
    protected DeviceOptions() { }
    public abstract AppiumOptions GetOptions();
    
    private class AndroidOptions : DeviceOptions
    {
        public override AppiumOptions GetOptions()
        {
            AppiumOptions appiumOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = Config.ReadFromAppSettings("PlatformName"),
                DeviceName = Config.ReadFromAppSettings("DeviceName"),
                App = Config.ReadFromAppSettings("App")
            };
            appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppPackage, Config.ReadFromAppSettings("AppPackage"));
            appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppActivity, Config.ReadFromAppSettings("AppActivity"));
            return appiumOptions;
        }
    }
    private class IOSOptions : DeviceOptions
    {
        public override AppiumOptions GetOptions()
        {
            return new AppiumOptions()
            {
                AutomationName = AutomationName.iOSXcuiTest,
                PlatformName = Config.ReadFromAppSettings("PlatformName"),
                DeviceName = Config.ReadFromAppSettings("DeviceName"),
                App = Config.ReadFromAppSettings("App")
            };
        }
    }
}
