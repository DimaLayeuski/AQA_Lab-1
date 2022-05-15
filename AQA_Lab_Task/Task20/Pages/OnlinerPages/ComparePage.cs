using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.OnlinerPages;

public class ComparePage : BasePage
{
    private const string END_POINT = "/compare";

    private static readonly By TitleBy = By.ClassName("b-offers-title");

    private static readonly By ScreenSizeBy =
        By.XPath("(//td[@class='product-table__cell']//span[contains (text(), 'Диагональ экрана')])");

    private static readonly By ScreenSizeInfoBy =
        By.XPath("(//div[@class='product-table-tip'])//span[@data-tip-term='Диагональ экрана']");

    private static readonly By ScreenSizeInfoTextBy = By.XPath("(//div[@class='product-table-tip__text'])");

    private static readonly By RemoveButtonBy =
        By.XPath("(//*[@class='product-summary']/ following-sibling :: a) [2]");

    private static readonly By ProductSummaryBy = By.CssSelector(".product-summary");

    public ComparePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.OnlinerUrl + END_POINT);
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

    public IWebElement Title => WaitService.WaitElementIsExist(TitleBy);
    public IWebElement ScreenSize => WaitService.WaitElementIsExist(ScreenSizeBy);
    public IWebElement ScreenSizeInfo => WaitService.WaitElementIsVisible(ScreenSizeInfoBy);
    public bool ScreenSizeInfoTextInvisible => WaitService.WaitUntilElementInvisible(ScreenSizeInfoTextBy);
    public IWebElement RemoveButton => WaitService.WaitElementToBeClickable(RemoveButtonBy);
    public ReadOnlyCollection<IWebElement> ProductSummary => WaitService.WaitUntilElementsPresent(ProductSummaryBy);
}