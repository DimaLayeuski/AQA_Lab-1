using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject1;

public class Test2
{
    private IWebDriver? _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test]
    public void SmokeTest1()
    {
        string selectAll = Keys.Control + "A";
        _driver.Navigate().GoToUrl("https://masterskayapola.ru/kalkulyator/laminata.html");
        IWebElement widthElement = _driver.FindElement(By.Name("calc_roomwidth"));
        IWebElement heightElement = _driver.FindElement(By.Name("calc_roomheight"));
        IWebElement lamWidthElement = _driver.FindElement(By.Name("calc_lamwidth"));
        IWebElement lamHeightElement = _driver.FindElement(By.Name("calc_lamheight"));
        IWebElement inpackElement = _driver.FindElement(By.Name("calc_inpack"));
        IWebElement priceElement = _driver.FindElement(By.Name("calc_price"));
        IWebElement layingDirectionElement = _driver.FindElement(By.Name("calc_direct"));
        IWebElement biasElement = _driver.FindElement(By.Name("calc_bias"));
        IWebElement walldistElement = _driver.FindElement(By.Name("calc_walldist"));
        IWebElement calculateElement = _driver.FindElement(By.ClassName("btn-lg"));
        
        IWebElement sLamElement = _driver.FindElement(By.Id("s_lam"));
        IWebElement lCountElement = _driver.FindElement(By.Id("l_count"));
        IWebElement lPacksElement = _driver.FindElement(By.Id("l_packs"));
        IWebElement lPriceElement = _driver.FindElement(By.Id("l_price"));
        IWebElement lOverElement = _driver.FindElement(By.Id("l_over"));
        IWebElement lTrashElement = _driver.FindElement(By.Id("l_trash"));
        
        widthElement.SendKeys(selectAll);
        widthElement.SendKeys("4");
        heightElement.SendKeys(selectAll);
        heightElement.SendKeys("2");
        lamWidthElement.SendKeys(selectAll);
        lamWidthElement.SendKeys("1200");
        lamHeightElement.SendKeys(selectAll);
        lamHeightElement.SendKeys("150");
        inpackElement.SendKeys(selectAll);
        inpackElement.SendKeys("10");
        priceElement.SendKeys(selectAll);
        priceElement.SendKeys("1000");
        SelectElement layingDirectionDropDown = new SelectElement(layingDirectionElement);
        layingDirectionDropDown.SelectByIndex(1);
        biasElement.SendKeys(selectAll);
        biasElement.SendKeys("400");
        walldistElement.SendKeys(selectAll);
        walldistElement.SendKeys("15");
        Thread.Sleep(1000);
        calculateElement.Click();
        
        Assert.Pass();
        Assert.Multiple(() =>
        {
            Assert.AreEqual("7.82", sLamElement.GetAttribute("value"));
            Assert.AreEqual("45", lCountElement.GetAttribute("value"));
            Assert.AreEqual("5", lPacksElement.GetAttribute("value"));
            Assert.AreEqual("9000", lPriceElement.GetAttribute("value"));
            Assert.AreEqual("5", lOverElement.GetAttribute("value"));
            Assert.AreEqual("9", lTrashElement.GetAttribute("value"));
        });
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}