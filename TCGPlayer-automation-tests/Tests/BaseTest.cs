using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TCGPlayer_automation_tests.Utils;


namespace TCGPlayer_automation_tests 
{
    public class BaseTest 
    {
        protected SampleScreen sampleScreen;
        Report report = new Report();
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            //TODO StartAppiumServer();
            report.StartReport();
        }

        [SetUp]
        public void SetUp()
        {
            DriverManager.GetInstance().InitializeDriver();
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
