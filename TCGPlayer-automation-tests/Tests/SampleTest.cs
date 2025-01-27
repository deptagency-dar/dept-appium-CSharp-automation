using NUnit.Framework;

namespace TCGPlayer_automation_tests.Tests 
{
    [TestFixture]
    public class SampleTest: BaseTest 
    {
        [Description("Entering a VALID username and checking that the user is able to login")]
        [Test]
        public void sampleTest() 
        {
            sampleScreen.tapCountrySelector();
            sampleScreen.tapCountry("Argentina");
            sampleScreen.tapLetsShop();
            
            Assert.Equals(sampleScreen.getErrorMessageText(), "Please enter your name");
        }
    }
}
