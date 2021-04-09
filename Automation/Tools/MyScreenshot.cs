using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tools
{
    public class MyScreenshot
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = driver.TakeScreenshot();
            string screenshotDirectory = Path.GetDirectoryName (Path.GetDirectoryName (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            // C:\Users\jurat\source\repos\Automation\Automation\screnshot
            string screenshotFolder = Path.Combine(screenshotDirectory, "screenshots");
            Directory.CreateDirectory(screenshotFolder);
            string screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH_mm_ss}.png";
            string screenshotPath = Path.Combine(screenshotFolder, screenshotName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            //Console.Out.WriteLine(Assembly.GetExecutingAssembly().Location);
        }
    }
}
