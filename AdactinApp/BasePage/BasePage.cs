
using System;
using System.IO;
using System.IO.Packaging;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationFramework
{
    // also knows as core page
    public class BasePage
    {
        public static IWebDriver driver;
        public static ExtentReports extentReport;
        public static ExtentTest Test;
        public static ExtentTest Step;


        #region Selenium init and close
        public void Selenium_init(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--incognito");
                chromeOptions.AddArgument("headless");
                
                IWebDriver chromeDriver = new ChromeDriver(chromeOptions);
                driver = chromeDriver;
            }
            else if(browser == "Firefox")
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("");

                driver = new FirefoxDriver(options);



            }
           
        }
        public void Selenium_close()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();

        }
        #endregion

        public void Write(By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, data + ": Data Entered Successfully");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, data + ": Data entrance failed" + ex);

            }

        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, "Clicked Successfully");
            }
            catch (Exception e)
            {
                TakeScreenshot(Status.Fail, "Click failed " + e);

            }
        }
        public void Clear(By by)
        {
            try
            {
                driver.FindElement(by).Clear();
                TakeScreenshot(Status.Pass, "Cleared Successfully");
            }
            catch (Exception e)
            {
                TakeScreenshot(Status.Fail, "Cleared failed " + e);

            }

        }
        public void OpenUrl(string url)
        {
            try
            {
                   driver.Url = url;
                TakeScreenshot(Status.Pass, url + " : opened successfully");
            }
            catch (Exception e)
            {
                TakeScreenshot(Status.Fail, "url not opened" + e);

            }
        }
        public string GetText(By by)
        {

            return driver.FindElement(by).Text;
        }
        public void Assertion (string expectedMessage, string actualMessage)
        {
            try
            {
                Assert.AreEqual(expectedMessage, actualMessage);
                TakeScreenshot(Status.Pass, "Assertion passed : Test Case Passed");
            }catch(Exception e)
            {
                TakeScreenshot(Status.Fail, "Assertion not passed" +  e);

            }
        }

        public static void CreateReport(string path)
        {
            extentReport = new ExtentReports();

            var sparkReporter = new ExtentSparkReporter(path);

            extentReport.AttachReporter(sparkReporter);

        }

        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"E:\AutomationTesting\AutomationFramework\TestSummary\images\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            Step.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());

        }
    }
}
