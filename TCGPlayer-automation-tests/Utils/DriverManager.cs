using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace TCGPlayer_automation_tests.Utils;

public sealed class DriverManager
{
    
    private DriverManager() { }

    private static DriverManager _instance;
    
    public static DriverManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DriverManager();
        }
        return _instance;
    }
    public ThreadLocal<AppiumDriver> driver = new ThreadLocal<AppiumDriver>();
    public AppiumDriver GetDriver() => driver.Value;
    
    public enum PlatformType
    {
        Android,
        iOS
    }

    public PlatformType getPlatformType()
    {
        PlatformType platform = (PlatformType)System.Enum.Parse(typeof(PlatformType), Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), true);
        return platform;
    }
    
    public void InitializeDriver()
    {
        PlatformType platformType = getPlatformType();
        switch (platformType)
        {
            case PlatformType.Android:
                GetInstance().driver.Value = InitializeAndroid();
                break;
            case PlatformType.iOS:
                GetInstance().driver.Value = InitializeiOS();
                break;
        }
    }

    public AppiumDriver InitializeAndroid()
    {
        return new AndroidDriver(
            new Uri("http://127.0.0.1:4723/"), 
            DeviceOptions.ANDROID.GetOptions()
        );
    }
    
    public AppiumDriver InitializeiOS()
    {
        return new IOSDriver(
            new Uri("http://127.0.0.1:4723/"), 
            DeviceOptions.IOS.GetOptions()
        );
    }

    public void TearDown()
    {
        GetDriver()?.Quit();
    }
}