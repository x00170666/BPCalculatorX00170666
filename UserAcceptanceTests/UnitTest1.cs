
using Microsoft.VisualStudio.TestTools.UnitTesting;

// NuGet install Selenium WebDriver package and Support Classes
using OpenQA.Selenium;

// NuGet install PhantomJS driver (or Chrome or Firefox...)
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UserAcceptanceTests
{
    [TestClass]
    public class UnitTest1
    {
        // .runsettings file contains test run parameters
        // e.g. URI for app
        // test context for this run

        //private TestContext testContextInstance;

        // test harness uses this property to initliase test context
        //public TestContext TestContext
        /*{
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        // URI for web app being tested
        private String webAppUri;

        // .runsettings property overriden in vsts test runner
        // release task
        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
            //This is pulling your URL from SeleniumTest.runsettings
            //this.webAppUri = "http://localhost:53135/";
        }*/

        [TestMethod]
        public void TestBP()
        {
            //This is what the pipeline needs
            //using (IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver")))
            //This is what Visual Studios needs
            using (IWebDriver driver = new ChromeDriver())
            {
                // any exception below result in a test fail

                // navigate to URI for temperature converter
                // web app running on IIS express
                //driver.Navigate().GoToUrl(webAppUri);

                // get weight in stone element
                IWebElement Systolic = driver.FindElement(By.Id("BP.Systolic"));
                // enter 10 in element
                Systolic.SendKeys("10");

                // get weight in stone element
                IWebElement diastolic = driver.FindElement(By.Id("BP.Diastolic"));
                // enter 10 in element
                diastolic.SendKeys("10");

        
                // submit the form
                driver.FindElement(By.Id("convertForm")).Submit();

                // explictly wait for result with "BPValue" item
                IWebElement BPValueElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("bpVal")));


                // item comes back like "BPValue: 200"
                String bmi = BPValueElement.Text.ToString();

                // 10 Celsius = 50 Fahrenheit, assert it
                StringAssert.Contains(bmi, "Your BP is 200");

                driver.Quit();
            }
        }
    }
}