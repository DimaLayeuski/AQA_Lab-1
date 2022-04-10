using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ShopingCartPage : BasePage
{
    private const string END_POINT = "/cart.html";

    //описание локатора
    private static readonly By CheckoutBy = By.Id("checkout");
    private static readonly By ItemNameBy = By.ClassName("inventory_item_name");

    //конструктор
    public ShopingCartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return Checkout.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    //Атомарные элементы
    public IWebElement Checkout => Driver.FindElement(CheckoutBy);
    public IWebElement ItemName => Driver.FindElement(ItemNameBy);
}