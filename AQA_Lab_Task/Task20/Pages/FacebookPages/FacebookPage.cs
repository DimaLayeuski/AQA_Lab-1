using System;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.FacebookPages;

public class FacebookPage : BasePage
{
    private const string END_POINT = "/onlinerby";

    private static readonly By PageNameBy = By.XPath("(//div//*//span[contains (text(),'onlíner')])[1]");
    private static readonly By InformationButtonBy =
        By.XPath("(//*[contains(text(), 'Информация') or contains(text(), 'About')]) [1]");
    private static readonly By InformationTagBy =
        By.XPath("(//*[contains(text(), 'ОБЩЕЕ') or contains(text(), 'GENERAL')])");
    
    public FacebookPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.FacebookUrl + END_POINT);
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
    public static IWebElement InformationButton => WaitService.WaitElementIsExist(InformationButtonBy);
    public static IWebElement InformationTag => WaitService.WaitElementIsVisible(InformationTagBy);
}