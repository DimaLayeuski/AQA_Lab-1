using NUnit.Framework;
using OpenQA.Selenium;
using Task16.Services;

namespace PageObject;

public class BaseTest
{
    protected IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new BrowserService().Driver;
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}