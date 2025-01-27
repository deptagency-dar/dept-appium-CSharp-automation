using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace TCGPlayer_automation_tests.Utils;

public class DriverSetup
{
    public AndroidDriver driver { get; private set; }

    public AndroidDriver InitializeAppium()
    {
        var appiumOptions = new AppiumOptions()
        {
            AutomationName = AutomationName.AndroidUIAutomator2,
            PlatformName = "Android",
            DeviceName = "Android pixel9simulator",
            App = "Apps/General-Store.apk"
        };

        driver = new AndroidDriver(
            new Uri("http://127.0.0.1:4723/"), 
            appiumOptions
        );
        return driver;
    }

    public void TearDown()
    {
        driver?.Quit();
    }
}
