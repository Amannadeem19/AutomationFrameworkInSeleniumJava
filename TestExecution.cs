using System;
using System.Configuration;
using System.Drawing;
using AutomationFramework.AdactinApp.BookingPage;
using AutomationFramework.AdactinApp.SearchHotelPage;
using AutomationFramework.AdactinApp.SelectHotelPage;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework
{
    [TestClass]
    public class TestExecution
    {
        LoginPage loginPage = new LoginPage();
        BasePage basePage = new BasePage();
        SearchPage searchPage = new SearchPage();
        SelectHotePage selectHotePage = new SelectHotePage();
        BookPage bookPage = new BookPage();



        #region Initializations and Cleanups

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string ResultFile = @"E:\AutomationTesting\AutomationFramework\TestSummary\TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            BasePage.CreateReport(ResultFile);

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            BasePage.extentReport.Flush();    
        }


        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }


        [TestInitialize]
        public void TestInit()
        {
            basePage.Selenium_init(ConfigurationManager.AppSettings["DeviceBrowser"].ToString());
            BasePage.Test = BasePage.extentReport.CreateTest(TestContext.TestName); 
        }

        [TestCleanup]
        public void TestCleanup()
        {
            basePage.Selenium_close();
        }

        #endregion



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Data.xml", "Login", DataAccessMethod.Sequential)]
        public void LoginWithValidDataAndInvalidData_TC01()
        {


            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string locator = TestContext.DataRow["locator"].ToString();
            string expectedMessage = TestContext.DataRow["message"].ToString();

            loginPage.Login("https://adactinhotelapp.com/index.php", username, password, locator, expectedMessage);


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Data2.xml", "Login", DataAccessMethod.Sequential)]
        public void SearchHotel_TC001()
        {
            basePage.Selenium_init("Chrome");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string locator = TestContext.DataRow["locator"].ToString();
            string expectedMessage = TestContext.DataRow["message"].ToString();

            loginPage.Login("https://adactinhotelapp.com/index.php", username, password, locator, expectedMessage);
            searchPage.searchHotel();
            basePage.Selenium_close();


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Data2.xml", "Login", DataAccessMethod.Sequential)]
        public void SelectHotel_TC001()
        {
           // basePage.Selenium_init("Chrome");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string locator = TestContext.DataRow["locator"].ToString();
            string expectedMessage = TestContext.DataRow["message"].ToString();

            loginPage.Login("https://adactinhotelapp.com/index.php", username, password, locator, expectedMessage);
            searchPage.searchHotel();
            selectHotePage.selectHotel();
            //basePage.Selenium_close();


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"Data2.xml", "Login", DataAccessMethod.Sequential)]
        public void BookHotel_TC001()
        {
            //basePage.Selenium_init("Chrome");
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string locator = TestContext.DataRow["locator"].ToString();
            string expectedMessage = TestContext.DataRow["message"].ToString();

            loginPage.Login("https://adactinhotelapp.com/index.php", username, password, locator, expectedMessage);
            searchPage.searchHotel();
            selectHotePage.selectHotel();
            bookPage.bookedHotel();
            //basePage.Selenium_close();


        }
    }
}
