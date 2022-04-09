using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject;

public class LoginTest : BaseTest
{
    [Test]
    public void Test_SuccessLogin()
    {
        LoginPage loginPage = new LoginPage(_driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();

        ProductsPage productsPage = new ProductsPage(_driver, false);
        
        Assert.AreEqual("PRODUCTS", productsPage.Title.Text);
    }
}