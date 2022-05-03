using System;
using OpenQA.Selenium;
using Task16.Services;

namespace Task16.Pages;

public class ComparePage : BasePage
{
    private const string END_POINT = "/compare";
    private static readonly By TitleBy = By.ClassName("b-offers-title");
    private static readonly By ScreenSizeBy = By.XPath("(//*/ancestor :: div//*[@class = 'product-table__wrapper'])[12]");
    private static readonly By ScreenSizeInfoBy = By.XPath("((//div[@class='product-table-tip'])[3]//span)[1]");
    private static readonly By RemoveButtonBy = By.XPath("(//*[@class='product-summary']/ following-sibling :: a) [2]");
    private static readonly string finishUrlBy = "/compare/qe65q80aauxru";

    public ComparePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
    public IWebElement ScreenSize => Driver.FindElement(ScreenSizeBy);
    public IWebElement ScreenSizeInfo => WaitService.WaitElementIsVisible(ScreenSizeInfoBy);
    public IWebElement RemoveButton => Driver.FindElement(RemoveButtonBy);
    public bool FinishUrl => WaitService.WaitUrlMatches(finishUrlBy);
}