using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Task18.Pages;
using Task18.Services;

namespace Task18.Tests;

public class OnlinerCatalogSearchTest : BaseTest
{
    [Test]
    public void SearchIFrame_PhoneNameInput_SearchResultIsPresented()
    {
        Actions actions = new Actions(Driver);
        var mainOnlinerPage = new MainOnlinerPage(Driver, true);
        JSService.JSClick(Driver, mainOnlinerPage.FastSearchInput);
        actions
            .SendKeys(mainOnlinerPage.FastSearchInput, Configurator.SearchExample)
            .Build()
            .Perform();
        Driver.SwitchTo().Frame(mainOnlinerPage.IFrame);
        var firstResultTitle = mainOnlinerPage.FirstResultTitle.Text;
        mainOnlinerPage.IFrameSearchInput.Clear();
        JSService.SetText(Driver, mainOnlinerPage.IFrameSearchInput, firstResultTitle);
        Assert.AreEqual(firstResultTitle, mainOnlinerPage.FirstResultTitle.Text);
    }
}