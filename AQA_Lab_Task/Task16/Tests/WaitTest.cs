using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using PageObject;
using Task16.Pages;

namespace Task16.Tests;

public class WaitTest : BaseTest
{
    [Test]
    public void OnlinerWaitTest()
    {
        Actions actions = new Actions(Driver);
         
        var tvPage = new TvPage(Driver, true);
        
        tvPage.FirstTvCheck.Click();
        tvPage.SecondTvCheck.Click();
        tvPage.CompareButton.Click();
        
        var comparePage = new ComparePage(Driver, false);
        
        actions
            .MoveToElement(comparePage.ScreenSize)
            .Build()
            .Perform();
        
        comparePage.ScreenSizeInfo.Click();
        Assert.IsTrue(comparePage.ScreenSizeInfo.Displayed);
        
        comparePage.ScreenSizeInfo.Click();
        Assert.IsTrue(comparePage.ScreenSizeInfoTextInvisible);
        
        comparePage.RemoveButton.Click();
        Assert.AreEqual(2, comparePage.ProductSummary.Count);
    }
}