using NUnit.Framework;
using FluentAssertions;

namespace TCGPlayer_automation_tests.Tests 
{
    [TestFixture]
    public class SampleTest: BaseTest 
    {
        [Description("Verify error message when trying to login without password")]
        [Test]
        public void sampleTest() 
        {
            sampleScreen.typeName("QA");
            sampleScreen.tapLogin();

            sampleScreen.getErrorMessageText().Should().Be("Password is required");
        }
    }
}
