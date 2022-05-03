using System;
using OpenQA.Selenium;
using Task16.Services;

namespace Task16.Pages;

public class FacebookPage : BasePage
{
    private const string END_POINT = "/onlinerby";
    private static readonly By PageNameBy = By.XPath("(//div//*//span[contains (text(),'onlíner')])[1]");
    
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
    
    public IWebElement PageName => WaitService.WaitElementIsExist(PageNameBy);
}