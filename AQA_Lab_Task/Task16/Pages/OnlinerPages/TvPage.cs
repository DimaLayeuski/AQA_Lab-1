using System;
using OpenQA.Selenium;
using Task16.Services;

namespace Task16.Pages;

public class TvPage : BasePage
{
    private const string END_POINT = "/tv";
    private static readonly By FirstTvCheckBy = By.XPath("((//div[@class='schema-product__group'])[1]//label)[1]");
    private static readonly By SecondTvCheckBy = By.XPath("((//div[@class='schema-product__group'])[2]//label)[1]");
    private static readonly By CompareButtonBy = By.ClassName("compare-button__sub_main");
    private static readonly By VkComBy = By.ClassName("footer-style__social-button_vk");
    private static readonly By FacebookBy = By.ClassName("footer-style__social-button_fb");
    private static readonly By TwitterBy = By.ClassName("footer-style__social-button_tw");

    public TvPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return FirstTvCheck.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IWebElement FirstTvCheck => WaitService.WaitElementIsExist(FirstTvCheckBy);
    public IWebElement SecondTvCheck => WaitService.WaitElementIsExist(SecondTvCheckBy);
    public IWebElement CompareButton => WaitService.WaitElementIsVisible(CompareButtonBy);
    public IWebElement VkCom => WaitService.WaitElementIsVisible(VkComBy);
    public IWebElement Facebook => WaitService.WaitElementIsVisible(FacebookBy);
    public IWebElement Twitter => WaitService.WaitElementIsVisible(TwitterBy);
}