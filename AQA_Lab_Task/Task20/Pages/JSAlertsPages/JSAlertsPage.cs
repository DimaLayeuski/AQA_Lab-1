using System;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.JSAlertsPages;

public class JSAlertsPage : BasePage
{
    private const string END_POINT = "/javascript_alerts";
    
    private static readonly By PageNameBy = By.XPath("//h3[contains (text(), 'JavaScript Alerts')]");
    private static readonly By JSAlertBy = By.XPath("//button[contains (text(), 'Click for JS Alert')]");
    private static readonly By JSConfirmBy = By.XPath("//button[contains (text(), 'Click for JS Confirm')]");
    private static readonly By JSPromptBy = By.XPath("//button[contains (text(), 'Click for JS Prompt')]");
    private static readonly By ResultBy = By.Id("result");

    public JSAlertsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.HerokuAppUrl + END_POINT);
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

    public IWebElement PageName => WaitService.WaitElementIsVisible(PageNameBy);
    public IWebElement JSAlert => WaitService.WaitElementToBeClickable(JSAlertBy);
    public IWebElement JSConfirm => WaitService.WaitElementToBeClickable(JSConfirmBy);
    public IWebElement JSPrompt => WaitService.WaitElementToBeClickable(JSPromptBy);
    public IWebElement Result => WaitService.WaitElementToBeClickable(ResultBy);
}