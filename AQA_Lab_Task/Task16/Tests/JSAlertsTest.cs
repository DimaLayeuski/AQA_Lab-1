using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using Task16.Pages.JSAlertsPages;

namespace Task16.Tests;

public class JSAlertsTest : BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void JavaScriptAlertsTest()
    {
        var jSAlertsPage = new JSAlertsPage(Driver, true);
        jSAlertsPage.JSAlert.Click();
        IAlert simpleAlert = Driver.SwitchTo().Alert();
        _logger.Info("{alertText}", simpleAlert.Text);
        simpleAlert.Accept();
        Assert.AreEqual("You successfully clicked an alert", jSAlertsPage.Result.Text);

        jSAlertsPage.JSConfirm.Click();
        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        _logger.Info("{alertText}", confirmationAlert.Text);
        confirmationAlert.Accept();
        Assert.AreEqual("You clicked: Ok", jSAlertsPage.Result.Text);

        jSAlertsPage.JSPrompt.Click();
        IAlert promptAlertDismiss = Driver.SwitchTo().Alert();
        promptAlertDismiss.Dismiss();
        Assert.AreEqual("You entered: null", jSAlertsPage.Result.Text);

        jSAlertsPage.JSPrompt.Click();
        IAlert promptAlertAccept = Driver.SwitchTo().Alert();
        _logger.Info("{alertText}", promptAlertAccept.Text);
        promptAlertAccept.SendKeys("Great site");
        _logger.Info("{alertText}", promptAlertAccept.Text);
        promptAlertAccept.Accept();
        Assert.AreEqual("You entered: Great site", jSAlertsPage.Result.Text);
    }
}