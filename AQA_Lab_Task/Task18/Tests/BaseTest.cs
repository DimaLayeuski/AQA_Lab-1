using NUnit.Framework;
using OpenQA.Selenium;
using Task18.Services;

namespace Task18.Tests;

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