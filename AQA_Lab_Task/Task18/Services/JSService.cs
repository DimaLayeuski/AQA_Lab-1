using OpenQA.Selenium;

namespace Task18.Services;

public static class JSService
{
    
    public static void JSClick(IWebDriver Driver, IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        js.ExecuteScript("arguments[0].click()", element);
    }
    
    public static void SetText(IWebDriver Driver,  IWebElement element, string text)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
        js.ExecuteScript(string.Format("arguments[0].value = \"{0}\";", text), element);
    }
}