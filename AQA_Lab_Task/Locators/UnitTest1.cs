using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

public class Tests
{
    private IWebDriver _driver;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(Endpoits.FullPathToIndex);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}