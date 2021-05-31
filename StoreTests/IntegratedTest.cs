using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreTests
{
  public   class IntegratedTest : IDisposable
    {
     
        private readonly IWebDriver _driver;
        public IntegratedTest()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
        
                [Fact]
                public void Create_WhenExecuted_ReturnsCreateView()
                {
                    _driver.Navigate().GoToUrl("https://projectp1.azurewebsites.net/Location/Create");
            //_driver.Navigate().GoToUrl("https://localhost:44391/Location/Create");

            Assert.Equal("Create Location - Tire Shop", _driver.Title);
         
                }
        [Fact]
        public void LocationCreatedSuccessfully_ShouldAppearOnIndexViewOfLocation()
        {
            _driver.Navigate().GoToUrl("https://projectp1.azurewebsites.net/Location/Create");
            //.Navigate().GoToUrl("https://localhost:44391/Location/Create");

            _driver.FindElement(By.Id("Name"))
                .SendKeys("St Valencia ");

            _driver.FindElement(By.Id("Address"))
                .SendKeys("34 CA");

            _driver.FindElement(By.Id("Create"))
                .Click();

            Assert.Equal("Index - Tire Shop", _driver.Title);
            Assert.Contains("St Valencia", _driver.PageSource);
            Assert.Contains("34", _driver.PageSource);
         
        }
    }
}
