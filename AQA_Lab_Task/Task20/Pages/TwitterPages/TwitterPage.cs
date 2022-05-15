using System;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.TwitterPages;

public class TwitterPage : BasePage
{
    private const string END_POINT = "/OnlinerBY";

    private static readonly By PageNameBy = By.XPath("(//div//*//span[contains (text(),'onlíner')])[1]");
    private static readonly By ExploreLinkBy = By.CssSelector("[href = '/explore']");

    public TwitterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.TwitterUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return PageName.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement PageName => WaitService.WaitElementIsExist(PageNameBy);
    public static IWebElement ExploreLink => WaitService.WaitElementToBeClickable(ExploreLinkBy);
}