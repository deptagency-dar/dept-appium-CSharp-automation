using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TCGPlayer_automation_tests.Utils;


namespace TCGPlayer_automation_tests 
{
    public class BaseTest
    {
        protected static Report report = new Report();
        protected SampleScreen sampleScreen;
        
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            AppiumServer.getAppiumServer();
            report.StartReport();
        }

        [SetUp]
        public void SetUp()
        {
            DriverManager.GetInstance().InitializeDriver();
            Console.WriteLine("Driver initialized");
            sampleScreen = new SampleScreen();
            report.CreateTest();
        }
        
        [TearDown]
        public void TearDown()
        {
            AttachScreenshotToTheReport();
            report.LogTestStatus();
            DriverManager.GetInstance().TearDown();
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => AppiumServer.stopServer();

        
        private void AttachScreenshotToTheReport()
        {
            try
            {
                if (DriverManager.GetInstance().GetDriver() != null)
                {
                    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                    {
                        var screenshot = DriverManager.GetInstance().GetDriver().GetScreenshot();
                        string screenshotPath = 
                            $"{TestContext.CurrentContext.Test.MethodName}-" +
                            $"{DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss")}.png";
                        screenshot.SaveAsFile(screenshotPath);
                        report.SaveScreenshotToReport(screenshot.AsBase64EncodedString);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Snapshot was not taken" + e.Message);
            }
        }
    }
}
