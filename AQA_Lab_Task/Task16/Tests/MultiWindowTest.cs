using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using Task16.Pages;

namespace Task16.Tests;

public class MultiWindowTest : BaseTest
{
    [Test]
    public void SocialMediaWindowsHandlingTest()
    {
        var tvPage = new TvPage(Driver, true);
        IJavaScriptExecutor js_executor = (IJavaScriptExecutor)Driver;
        js_executor.ExecuteScript("arguments[0].click()", tvPage.Twitter);
        js_executor.ExecuteScript("arguments[0].click()", tvPage.Facebook);
        js_executor.ExecuteScript("arguments[0].click()", tvPage.Vk);

        var windows = Driver.WindowHandles;
        Driver.SwitchTo().Window(windows[1]);
        VkPage.LoginButton.Click();
        Assert.IsTrue(IdVkPage.PageName.Displayed);

        Driver.SwitchTo().Window(windows[2]);
        FacebookPage.InformationButton.Click();
        Assert.IsTrue(FacebookPage.InformationTag.Displayed);

        Driver.SwitchTo().Window(windows[3]);
        TwitterPage.ExploreLink.Click();
        Assert.IsTrue(TwitterExplorerPage.PageName.Displayed);
    }
}