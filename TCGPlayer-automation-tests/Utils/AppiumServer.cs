using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;

namespace TCGPlayer_automation_tests.Utils;

public class AppiumServer
{
    private static AppiumLocalService _service;
    
    private AppiumServer()
    {
        startServer();
    }
    
    public static AppiumLocalService getAppiumServer() {
        if (_service == null)
        {
            Console.WriteLine("Server not initialized");
            new AppiumServer();
        }
        if (!_service.IsRunning)
        {
            Console.WriteLine("Server not running");
            stopServer();
            startServer();
        } 
        return _service;
    }
    
    private static void startServer() {
        AppiumServiceBuilder builder = new AppiumServiceBuilder()
            .WithIPAddress(Config.ReadFromGlobalConfig("appium.ip"))
            .UsingPort(int.Parse(Config.ReadFromGlobalConfig("appium.port")))
            .WithLogFile(createAppiumLog());
        _service = builder.Build();
        try {
            Console.WriteLine("Starting server");
            _service.Start();
            Console.WriteLine($"✅ Appium started at: {_service.ServiceUrl}");
        } catch (Exception e) {
            throw new Exception(
                "AppiumServer - Appium server could not started. Original Error: " + e.Message);
        }
        if (_service == null || !_service.IsRunning) {
            throw new Exception("AppiumServer - Appium server did not started correctly.");
        }
    }

    public static void stopServer()
    {
        if (_service != null)
        {
            _service.Dispose();
        }
    }
    
    private static FileInfo createAppiumLog()
    {
        string logPath = $"{DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss")}.log";
        return new FileInfo(logPath);
    }
    
}