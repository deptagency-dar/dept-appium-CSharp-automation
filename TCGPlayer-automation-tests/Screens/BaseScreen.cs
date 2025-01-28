using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using TCGPlayer_automation_tests.Utils;

namespace TCGPlayer_automation_tests
{
    public abstract class BaseScreen
    {
        protected AppiumDriver driver;

        protected BaseScreen()
        {
            driver = DriverManager.GetInstance().GetDriver();
        }

        protected void tap(By element)
        {
            waitForElement(element);
            try
            {
                driver.FindElement(element).Click();
                //Report.test.Info($"Clicked on element {element}");
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to click on the element: {element}. {e.Message}");
            }

        }

        protected void type(By element, string text)
        {
            waitForElement(element);
            try
            {
                driver.FindElement(element).SendKeys(text);
                //Report.test.Info($"Sent keys to element {element}");
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to send keys to the element: {element}. {e.Message}");
            }

        }
        
        protected bool isElementAppears(By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void waitForElement(By element)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} Failed: {e.Message}");
            }
        }

        protected String getText(By element)
        {
            waitForElement(element);
            if (driver.PlatformName.ToLower().Equals("ios"))
            {
                return driver.FindElement(element).Text;
            }
            else
            {
                return driver.FindElement(element).FindElement(By.ClassName("android.widget.TextView")).Text;
            }
        }

        protected void switchToNativeContext()
        {
            try
            {
                driver.Context = "NATIVE_APP";
                Report.test.Info("Context has switched to native app");
            }
            catch (Exception e)
            {
                throw new Exception($"Switching to native view failed: {e.Message}");
            }

        }

        protected void switchToWebViewContext(string requiredContext)
        {
            try
            {
                foreach (var context in driver.Contexts)
                {
                    if (context.Contains(requiredContext))
                        driver.Context = context;
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