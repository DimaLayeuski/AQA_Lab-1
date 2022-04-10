using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutStepOnePage : BasePage
{
    private const string END_POINT = "/checkout-step-one.html";

    //описание локатора
    private static readonly By ContinueBy = By.Id("continue");
    private static readonly By FirstNameBy = By.Id("first-name");
    private static readonly By LastNameBy = By.Id("last-name");
    private static readonly By PostalCodeBy = By.Id("postal-code");
    
    //конструктор
    public CheckoutStepOnePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return Continue.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    //Атомарные элементы
    public IWebElement Continue => Driver.FindElement(ContinueBy);
    public IWebElement FirstName => Driver.FindElement(FirstNameBy);
    public IWebElement LastName => Driver.FindElement(LastNameBy);
    public IWebElement PostalCode => Driver.FindElement(PostalCodeBy);
}