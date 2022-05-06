using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject1;

public class Test1
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void SmokeTest1()
    {
        _driver.Navigate().GoToUrl("https://kermi-fko.ru/raschety/Calc-Rehau-Solelec.aspx");
        IWebElement widthElement = _driver.FindElement(By.Id("el_f_width"));
        IWebElement lenghtElement = _driver.FindElement(By.Id("el_f_lenght"));
        IWebElement roomElement = _driver.FindElement(By.Id("room_type"));
        IWebElement heatingTypeElement = _driver.FindElement(By.Id("heating_type"));
        IWebElement heatLossElement = _driver.FindElement(By.Id("el_f_losses"));
        IWebElement calculateElement = _driver.FindElement(By.ClassName("buttHFcalc"));
        IWebElement floorCablePowerElement = _driver.FindElement(By.Id("floor_cable_power"));
        IWebElement specFloorCablePowerElement = _driver.FindElement(By.Id("spec_floor_cable_power"));

        widthElement.SendKeys("3");
        lenghtElement.SendKeys("4");
        SelectElement roomDropDown = new SelectElement(roomElement);
        roomDropDown.SelectByValue("2");
        SelectElement heatingTypeDropDown = new SelectElement(heatingTypeElement);
        heatingTypeDropDown.SelectByValue("2");
        heatLossElement.SendKeys("50");
        calculateElement.Click();
        
        Assert.Multiple(() =>
        {
            Assert.AreEqual("53", floorCablePowerElement.GetAttribute("value"));
            Assert.AreEqual("4", specFloorCablePowerElement.GetAttribute("value"));
        });
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}