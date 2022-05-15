using System;
using OpenQA.Selenium;
using Task20.Services;

namespace Task20.Pages.VkPages;

public class VkPage : BasePage
{
    private const string END_POINT = "/onliner";

    private static readonly By PageNameBy = By.ClassName("page_name");
    private static readonly By LoginButtonBy = By.CssSelector("[class='quick_login_button flat_button button_wide']");

    public VkPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.VkComUrl + END_POINT);
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
    public static IWebElement LoginButton => Driver.FindElement(LoginButtonBy);
}