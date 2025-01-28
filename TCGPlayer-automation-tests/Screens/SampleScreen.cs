using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;

namespace TCGPlayer_automation_tests;

public class SampleScreen : BaseScreen
{


    private By nameField => MobileBy.AccessibilityId("test-Username");
    
    private By loginButton => MobileBy.AccessibilityId("test-LOGIN");
    
    private By errorMessage => MobileBy.AccessibilityId("test-Error message");

    public void typeName(String name) {
        type(nameField, name);
    }

    public void tapLogin()
    {
        tap(loginButton);
    }

    public string getErrorMessageText()
    {
        return getText(errorMessage);
    }
}