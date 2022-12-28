using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;

namespace Vicious_Scraper
{
    class VS_Scaper
    {
        public void Scrape()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl("https://www.vicioussyndicate.com/data-reaper-live-beta/");

            IWebElement basicBtn = driver.FindElement(By.Id("basicBtn"));
            driver.ExecuteJavaScript("arguments[0].click();", basicBtn);
            Thread.Sleep(1000);

            IWebElement table = driver.FindElement(By.Id("table"));
            driver.ExecuteJavaScript("arguments[0].click();", table);
            Thread.Sleep(1000);

            IWebElement showNum = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/article/div[2]/div/div[2]/div[4]/div[1]/div[2]/button[2]"));
            driver.ExecuteJavaScript("arguments[0].click();", showNum);

            IReadOnlyCollection<IWebElement> dataElts = driver.FindElements(By.ClassName("textpoint"));
            DataPointDictionary dataPoints = new DataPointDictionary();

            foreach (IWebElement elt in dataElts)
            {
                decimal val;
                string wr = elt.Text;
                if (wr.Equals(" X "))
                    val = 50;
                else
                    val = decimal.Parse(wr.TrimEnd('%'));
                IWebElement text = elt.FindElement(By.TagName("text"));
                decimal x = decimal.Parse(text.GetAttribute("x"));
                decimal y = decimal.Parse(text.GetAttribute("y"));
                DataPoint dp = new DataPoint(val, x, y);
                dataPoints.Add(x, dp);
            }

            driver.Dispose();

            dataPoints.SortAll();
            var keys = dataPoints.Keys.ToList();
            var firstkey = keys[0];

            for (int i = 0; i < 17; i++)
            {
                ///System.Diagnostics.Debug.Write((dataPoints[firstkey])[i].val + "\n");
                Console.Write(dataPoints[0, i] + "\n");
            }
            Thread.Sleep(10000);
        }
    }
}
