using System;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.TwitterPages;

public class TwitterExplorerPage : BasePage
{
    private const string END_POINT = "/explore";

    private static readonly By PageNameBy = By.XPath("(//div//*//span[contains (text(),'Актуальные темы для вас')])");

    public TwitterExplorerPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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

    public static IWebElement PageName => WaitService.WaitElementIsExist(PageNameBy);
}