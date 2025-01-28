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
                PlatformName = "Android",
                DeviceName = "Android pixel9simulator",
                App = "Apps/Android.SauceLabs.Mobile.Sample.app.2.7.1.apk"
            };
            appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppPackage, "com.swaglabsmobileapp");
            appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AppActivity, "com.swaglabsmobileapp/.MainActivity");
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
                PlatformName = "iOS",
                DeviceName = "iosSimulator16",
                App = "Apps/iOS.Simulator.SauceLabs.Mobile.Sample.app.2.7.1.app"
            };
        }
    }
}
