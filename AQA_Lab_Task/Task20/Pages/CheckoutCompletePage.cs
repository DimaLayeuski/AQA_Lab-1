using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CheckoutCompletePage : BasePage
{
    private const string END_POINT = "/checkout-complete.html";
    private static readonly By BackToProductsBy = By.Id("back-to-products");

    public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return BackToProducts.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement BackToProducts => Driver.FindElement(BackToProductsBy);
}