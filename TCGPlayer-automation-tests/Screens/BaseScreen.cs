using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace TCGPlayer_automation_tests
{
    public class BaseScreen
    {
        public static ThreadLocal<AppiumDriver> driver = new ThreadLocal<AppiumDriver>();
        public static AppiumDriver GetDriver() => driver.Value;

        public void tap(By element)
        {
            waitForElement(element);
            try
            {
                GetDriver().FindElement(element).Click();
                Report.test.Info($"Clicked on element {element}");
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to click on the element: {element}. {e.Message}");
            }

        }

        public void type(By element, string text)
        {
            waitForElement(element);
            try
            {
                GetDriver().FindElement(element).SendKeys(text);
                Report.test.Info($"Sent keys to element {element}");
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to send keys to the element: {element}. {e.Message}");
            }

        }
        
        public bool isElementAppears(By element)
        {
            try
            {
                GetDriver().FindElement(element);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void waitForElement(By element)
        {
            try
            {
                new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} Failed: {e.Message}");
            }
        }

        public void switchToNativeContext()
        {
            try
            {
                GetDriver().Context = "NATIVE_APP";
                Report.test.Info("Context has switched to native app");
            }
            catch (Exception e)
            {
                throw new Exception($"Switching to native view failed: {e.Message}");
            }

        }

        public void switchToWebViewContext(string requiredContext)
        {
            try
            {
                foreach (var context in GetDriver().Contexts)
                {
                    if (context.Contains(requiredContext))
                        GetDriver().Context = context;
                }
                Report.test.Info($"Context has switched to webview {requiredContext}");
            }
            catch (Exception e)
            {
                throw new Exception($"Switching to web view failed: {e.Message}");
            }
        }
    }
}