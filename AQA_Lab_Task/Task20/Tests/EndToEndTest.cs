using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject;

[AllureNUnit]
[AllureStory]
[AllureSeverity(SeverityLevel.blocker)]
[AllureTag("E2E Critical path")]
[AllureLabel("Priority", "High")]
[AllureSuite("E2E SauceDemo")]
[AllureOwner("Dima Layeuski")]
public class EndToEndTest : BaseTest
{
    [Test]
    [Category("EndToEnd")]
    public void Test_EndToEnd()
    {
        //Test_SuccessLogin
        LoginPage loginPage = new LoginPage(_driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
        ProductsPage productsPage = new ProductsPage(_driver, false);
        Assert.AreEqual("PRODUCTS", productsPage.Title.Text);

        //Test_SuccessChoseProduct
        productsPage.AddToCart.Click();
        productsPage.ShopingCart.Click();
        ShopingCartPage shopingCartPage = new ShopingCartPage(_driver, false);
        Assert.AreEqual("Sauce Labs Backpack", shopingCartPage.ItemName.Text);

        //Test_SuccessBuyProduct
        shopingCartPage.Checkout.Click();
        CheckoutStepOnePage checkoutStepOnePage = new CheckoutStepOnePage(_driver, false);
        Assert.AreEqual("CHECKOUT: YOUR INFORMATION", checkoutStepOnePage.Title.Text);

        //Test_SuccessStepOne
        checkoutStepOnePage.FirstName.SendKeys(Configurator.FirstName);
        checkoutStepOnePage.LastName.SendKeys(Configurator.LastName);
        checkoutStepOnePage.PostalCode.SendKeys(Configurator.PostalCode);
        checkoutStepOnePage.Continue.Click();
        CheckoutStepTwoPage checkoutStepTwoPage = new CheckoutStepTwoPage(_driver, false);
        Assert.AreEqual("CHECKOUT: OVERVIEW", checkoutStepTwoPage.Title.Text);

        //Test_SuccessStepTwo
        checkoutStepTwoPage.Finish.Click();
        CheckoutCompletePage checkoutCompletePage = new CheckoutCompletePage(_driver, false);
        Assert.AreEqual("CHECKOUT: COMPLETE!", checkoutStepTwoPage.Title.Text);

        //Test_SuccessCheckoutComlete
        checkoutCompletePage.BackToProducts.Click();
        Assert.AreEqual("PRODUCTS", productsPage.Title.Text);

        //Test_LogOut
        productsPage.ReactMenu.Click();
        productsPage.LogOut.Click();
        Assert.IsTrue(loginPage.LoginButton.Displayed);
    }
}