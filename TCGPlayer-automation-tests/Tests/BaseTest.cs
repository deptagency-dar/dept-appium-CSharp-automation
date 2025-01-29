using NUnit.Framework;
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
}
