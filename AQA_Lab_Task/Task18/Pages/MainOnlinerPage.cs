using System;
using OpenQA.Selenium;
using Task18.Services;

namespace Task18.Pages;

public class MainOnlinerPage : BasePage
{
    private const string END_POINT = "/";

    private static readonly By FastSearchInputBy = By.ClassName("fast-search__input");
    private static readonly By IFrameSearchInputBy = By.XPath("(//*[@class='search__input'])");
    private static readonly By FirstResultTitleBy = By.XPath("(//*[@class='product__title-link'])[1]");
    private static readonly By IFrameBy = By.XPath("(//*[@class='modal-iframe'])");

    public MainOnlinerPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
            return FastSearchInput.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement FastSearchInput => WaitService.WaitElementIsVisible(FastSearchInputBy);
    public IWebElement FirstResultTitle => WaitService.WaitElementIsVisible(FirstResultTitleBy);
    public IWebElement IFrame => WaitService.WaitElementIsVisible(IFrameBy);
    public IWebElement IFrameSearchInput => WaitService.WaitElementIsVisible(IFrameSearchInputBy);
}