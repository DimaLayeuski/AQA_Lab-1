using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepTwoPage : BasePage
{
    private const string END_POINT = "/checkout-step-two.html";

    //описание локатора
    private static readonly By FinishBy = By.Id("finish");
    
    //конструктор
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
    
    //Атомарные элементы
    public IWebElement Finish => Driver.FindElement(FinishBy);
}