using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using TCGPlayer_automation_tests.Utils;

namespace TCGPlayer_automation_tests 
{
    public class BaseTest 
    {
        protected SampleScreen sampleScreen;

        [SetUp]
        public void SetUp()
        {
            DriverManager.GetInstance().InitializeDriver();
            sampleScreen = new SampleScreen();
        }
        
        [TearDown]
        public void TearDown()
        {
            DriverManager.GetInstance().TearDown();
        }

       
    }
    //     AppiumLocalService appiumLocalService;
    //     PlatformCapabilities platformCapabilities = new PlatformCapabilities();
    //     AppiumOptions appiumOptions = new AppiumOptions();
    //     AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder();
    //     Report report = new Report();
    //     ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
    //     private readonly string url = Startup.ReadFromAppSettings("AppUrl");
    //
    //     protected SampleScreen sampleScreen;
    //
    //     private enum PlatformType
    //     {
    //         Android,
    //         iOS
    //     }
    //
    //     private AppiumDriver InitializeDriver(PlatformType platformType)
    //     {
    //         switch (platformType)
    //         {
    //             case PlatformType.Android:
    //                 appiumOptions = platformCapabilities.InitAndroidCapabilities();
    //                 BaseScreen.driver.Value = new AndroidDriver(appiumOptions);
    //                 sampleScreen = new SampleScreen();
    //                 break;
    //             // case PlatformType.iOS:
    //             //     appiumOptions = platformCapabilities.InitIOSCapabilities();
    //             //     BasePage.driver.Value = new IOSDriver<IWebElement>(uri, appiumOptions);
    //             //     sampleScreen = new sampleScreenNative();
    //             //     break;
    //             default:
    //                 throw new Exception("No platform selected!");
    //         }
    //
    //         return BaseScreen.GetDriver();
    //     }
    //
    //
    //     private void StartAppiumServer()
    //     {
    //         appiumServiceBuilder
    //             .UsingAnyFreePort();
    //         appiumLocalService = appiumServiceBuilder.Build();
    //         if (!appiumLocalService.IsRunning)
    //             appiumLocalService.Start();
    //     }
    //
    //     private void CloseAppiumServer()
    //     {
    //         if (appiumLocalService.IsRunning)
    //             appiumLocalService.Dispose();
    //     }
    //
    //     private void SetUpDriver()
    //     {
    //         Enum.TryParse(Startup.ReadFromAppSettings("PlatformType"), out PlatformType platformType);
    //         BaseScreen.driver.Value = InitializeDriver(platformType);
    //     }
    //
    //     private void CloseDriver() => BaseScreen.GetDriver()?.Quit();
    //
    //     private void AttachScreenshotToTheReport()
    //     {
    //         try
    //         {
    //             if (BaseScreen.GetDriver() != null)
    //             {
    //                 if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
    //                 {
    //                     var screenshot = BaseScreen.GetDriver().GetScreenshot();
    //                     string screenshotPath = $"{TestContext.CurrentContext.Test.MethodName}.png";
    //                     screenshot.SaveAsFile(screenshotPath);
    //                     report.SaveScreenshotToReport(screenshotPath);
    //                 }
    //             }
    //         }
    //         catch (Exception e)
    //         {
    //             throw new Exception("Snapshot was not taken" + e.Message);
    //         }
    //     }
    //
    //     private void SetLandscapeOrientation()
    //     {
    //         BaseScreen.GetDriver().Orientation = ScreenOrientation.Landscape;
    //         Report.test.Info($"Browser has switched to landscape orientation");
    //     }
    //
    //     private void NavigateToWebApp()
    //     {
    //         SetLandscapeOrientation();
    //         BaseScreen.GetDriver().Navigate().GoToUrl(url);
    //         Report.test.Info($"Browser navigated to {url}");
    //     }
    //
    //     private IConfigurationRoot BuildTestDataFile() => configurationBuilder.AddJsonFile(@"Utils\TestsData.json").Build();
    //
    //     protected string GetData(string value) => BuildTestDataFile().GetSection(value).Value;
    //
    //     [OneTimeSetUp]
    //     public void OneTimeSetUp()
    //     {
    //         StartAppiumServer();
    //         report.StartReport();
    //     }
    //
    //
    //     [OneTimeTearDown]
    //     public void OneTimeTearDown() => CloseAppiumServer();
    //
    //
    //     [SetUp]
    //     public void SetUp()
    //     {
    //         report.CreateTest();
    //         SetUpDriver();
    //     }
    //
    //
    //     [TearDown]
    //     public void TearDown()
    //     {
    //         AttachScreenshotToTheReport();
    //         report.LogTestStatus();
    //         CloseDriver();
    //     }
    // }
}
