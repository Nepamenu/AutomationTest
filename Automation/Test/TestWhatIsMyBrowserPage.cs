using OpenQA.Selenium;

namespace Automation.Test
{
    internal class TestWhatIsMyBrowserPage
    {
        private IWebDriver driver;

        public TestWhatIsMyBrowserPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}