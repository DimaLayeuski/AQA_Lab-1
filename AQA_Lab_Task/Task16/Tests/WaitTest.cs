using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using PageObject;
using Task16.Pages;
using Task16.Services;

namespace Task16.Tests;

public class WaitTest : BaseTest
{
    [Test]
    public void OnlinerWaitTest()
    {
        Actions actions = new Actions(_driver);
         
        var tvPage = new TvPage(_driver, true);
        
        tvPage.FirstTvCheck.Click();
        tvPage.SecondTvCheck.Click();
        tvPage.CompareButton.Click();
        
        var comparePage = new ComparePage(_driver, false);
        
        actions
            .MoveToElement(comparePage.ScreenSize)
            .Build()
            .Perform();
        actions
            .MoveToElement(comparePage.ScreenSizeInfo)
            .Click()
            .Build()
            .Perform();;
        comparePage.ScreenSizeInfo.Click();
        Assert.IsTrue(comparePage.ScreenSizeInfo.Displayed);
        comparePage.RemoveButton.Click();
        Assert.IsTrue(comparePage.FinishUrl);
    }
}