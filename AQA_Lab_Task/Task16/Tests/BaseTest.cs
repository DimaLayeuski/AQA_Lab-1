using NUnit.Framework;
using OpenQA.Selenium;
using Task16.Services;

namespace PageObject;

public class BaseTest
{
    protected IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new BrowserService().Driver;
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}