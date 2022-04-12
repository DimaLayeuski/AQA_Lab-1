using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string END_POINT = "/inventory.html";
    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By AddToCartBy = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By ShopingCartBy = By.ClassName("shopping_cart_badge");
    private static readonly By ReactMenuBy = By.Id("react-burger-menu-btn");
    private static readonly By LogOutBy = By.Id("logout_sidebar_link");

    public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return Title.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement Title => Driver.FindElement(TitleBy);
    public IWebElement AddToCart => Driver.FindElement(AddToCartBy);
    public IWebElement ShopingCart => Driver.FindElement(ShopingCartBy);
    public IWebElement ReactMenu => Driver.FindElement(ReactMenuBy);
    public IWebElement LogOut => WaitService.WaitElementIsVisible(LogOutBy);
}