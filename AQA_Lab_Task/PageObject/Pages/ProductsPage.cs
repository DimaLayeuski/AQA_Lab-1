using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string END_POINT = "/inventory.html";
    
    //описание локатора
    private static readonly By TitleBy = By.ClassName("title");
    private static readonly By AddToCartBy = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By ShopingCartBy = By.ClassName("shopping_cart_badge");
    
    //конструктор
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
    
    //Атомарные элементы
    public IWebElement Title => Driver.FindElement(TitleBy);
    public IWebElement AddToCart => Driver.FindElement(AddToCartBy);
    public IWebElement ShopingCart => Driver.FindElement(ShopingCartBy);
}