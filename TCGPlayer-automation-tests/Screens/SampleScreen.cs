using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;

namespace TCGPlayer_automation_tests;

public class SampleScreen : BaseScreen
{
    private By countrySelector =>
        By.XPath("//android.widget.Spinner[@resource-id='com.androidsample.generalstore:id/spinnerCountry']");

    private By nameField => MobileBy.Id("com.androidsample.generalstore:id/nameField");
    
    private By maleOption => MobileBy.Id("com.androidsample.generalstore:id/radioMale");
    
    private By femaleOption => MobileBy.Id("com.androidsample.generalstore:id/radioFemale");
    
    private By letsShop => MobileBy.Id("com.androidsample.generalstore:id/btnLetsShop");
    
    private By errorMessage => MobileBy.XPath("//android.widget.Toast[@text='Please enter your name']");
    
    public void tapCountrySelector() {
        tap(countrySelector);
    }

    public void tapCountry(String country) {
        GetDriver().FindElement(
                MobileBy.XPath(
                    ("//android.widget.TextView[@resource-id='android:id/text1' and @text='" + country + "']")))
            .Click();
    }

    public void tapLetsShop()
    {
        tap(letsShop);
    }

    public void typeName(String name) {
        type(nameField, name);
    }

    public void selectMaleOption() {
        tap(maleOption);
    }

    public string getErrorMessageText()
    {
        return errorMessage.ToString();
    }
}