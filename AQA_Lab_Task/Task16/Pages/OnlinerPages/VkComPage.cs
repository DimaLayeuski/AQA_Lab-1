using System;
using OpenQA.Selenium;
using Task16.Services;

namespace Task16.Pages;

public class VkComPage : BasePage
{
    private const string END_POINT = "/onliner";
    private static readonly By PageNameBy = By.ClassName("page_name");

    public VkComPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
}