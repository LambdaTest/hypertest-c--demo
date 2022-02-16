using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HyperTestDemo
{
    public class DriverFactory
    {
        static DriverFactory()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
        }

        public static IWebDriver GetDriver(string testName, int makeSlowerFactor = 1)
        {
            string username = "<username>";
            string authkey = "<accesskey>";

            ////var capabilities = new ChromeOptions();
            ////capabilities.BrowserVersion = "97.0";
            ////var ltOptions = new Dictionary<string, object>();
            ////ltOptions.Add("user", username);
            ////ltOptions.Add("accessKey", authkey);
            ////ltOptions.Add("build", "your build name");
            ////ltOptions.Add("name", testName);
            ////ltOptions.Add("platformName", "Windows 10");
            ////ltOptions.Add("selenium_version", "3.13.0");
            ////ltOptions.Add("driver_version", "98.0");
            ////capabilities.AddAdditionalCapability("LT:Options", ltOptions);

            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accesskey", authkey);
            // capabilities.SetCapability("geoLocation", "US");

            capabilities.SetCapability("build", "HyperTest Demo for Geekle US");
            capabilities.SetCapability("name", "HyperTest Demo for Geekle US");
            capabilities.SetCapability("platformName", "Windows 10");
            capabilities.SetCapability("browser", "Chrome");
            capabilities.SetCapability("browser_version", "97.0");

            IWebDriver driver = new RemoteWebDriver(new Uri("https://" + username + ":" + authkey + "@hub.lambdatest.com/wd/hub"), capabilities);
            Console.WriteLine("https://" + username + ":" + authkey + "@hub.lambdatest.com/wd/hub");
            EventFiringWebDriver firedDriver = new EventFiringWebDriver(driver);
            firedDriver.FindingElement += (s, e) => Thread.Sleep(makeSlowerFactor * 50);
            firedDriver.Manage().Window.Maximize();

            return firedDriver;
        }
    }
}
