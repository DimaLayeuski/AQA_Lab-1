using System;
using OpenQA.Selenium;

namespace Task16.Pages;

public class IdVkPage : BasePage
{
    private const string END_POINT = "https://id.vk.com/";
    
    private static readonly By PageNameBy = By.ClassName("vkc__PromoBox__title");

    public IdVkPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(END_POINT);
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