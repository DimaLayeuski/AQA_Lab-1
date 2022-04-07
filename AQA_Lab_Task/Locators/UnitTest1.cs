using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators;

public class Tests
{
    private IWebDriver _driver;
    private static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    private static readonly string FullPathToIndex =
        $"file:{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}index.html";

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(FullPathToIndex);
    }

    [Test]
    public void xPath_Locator_Test()
    {
        Assert.Multiple(() =>
        {
            // 1. Отобразить второй элемент содержащий текст 'Test'
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains (text(),'Test')][2]")).Displayed);
            // 2. Отобразить элемент текст в котором равен 'Test' и атрибут равный 'ids'
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains (text(),'Test')][@ids]")).Displayed);
            // 3. Отобрать элемент с текстом 'Title 2'
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains (text(),'Title 2')]")).Displayed);
            // 4. Отобрать элемент h1 который содержит элемент с текстом 'Title 3'
            Assert.IsTrue(_driver.FindElement(By.XPath("//h1//*[contains(text(),'Title 3')]")).Displayed);
            // 5. Отобрать второй элемент класса 'arrow' из блока в котором присутствует текст 'Title 2' 
            Assert.IsTrue(_driver.FindElement(
                By.XPath("(//*[normalize-space() ='Title 2']/ancestor :: div//*[@class = 'arrow'])[2]")).Displayed);
        });
    }

    [Test]
    public void Css_Locator_Test()
    {
        Assert.Multiple(() =>
        {
            // 1. Отобразить элемент с текстом 'Locator'
            Assert.IsTrue(_driver.FindElement(By.CssSelector("span[id='123']")).Displayed);
            // 2. Отобрать элементы с классом 'arrow'
            Assert.IsTrue(_driver.FindElement(By.CssSelector("[class='arrow']")).Displayed);
            // 3. Отобразить элемент с id = '123'
            Assert.IsTrue(_driver.FindElement(By.CssSelector("[id='123']")).Displayed);
            // 4. Отобрать все элементы <span> у которых родителями является <h1>
            Assert.AreEqual(6, _driver.FindElements(By.CssSelector("h1 span")).Count);
            // 5. Отобрать все элементы <span> у которых параметр value начинается с '12'
            Assert.AreEqual(2, _driver.FindElements(By.CssSelector("span[value^='12']")).Count);
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver.Quit();
    }
}