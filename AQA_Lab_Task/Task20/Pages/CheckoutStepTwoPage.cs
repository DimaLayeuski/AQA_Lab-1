using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepTwoPage : BasePage
{
    private const string END_POINT = "/checkout-step-two.html";
    private static readonly By FinishBy = By.Id("finish");
    private static readonly By TitleBy = By.XPath("//*[contains (text(),'Checkout')]");

    public CheckoutStepTwoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Finish.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement Finish => Driver.FindElement(FinishBy);
    public IWebElement Title => Driver.FindElement(TitleBy);
}