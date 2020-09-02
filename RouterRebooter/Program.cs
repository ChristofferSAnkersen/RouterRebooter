using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace RouterRebooter
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //const string name = "admin";
                const string password = "PASSWORD";
                Uri url = new Uri("http://192.168.0.1/0.1/gui/#/login/");

                // Open Chrome
                ChromeDriver chrome = new ChromeDriver();
                chrome.Navigate().GoToUrl(url);

                // Username (if not already filled)
                //IWebElement userField = chrome.FindElementById("name");
                //userField.SendKeys(name);

                // Password
                IWebElement passwordField = chrome.FindElementById("password");
                passwordField.SendKeys(password);

                //Submit
                IWebElement submit = chrome.FindElementById("button-blue");
                submit.Click();

                Thread.Sleep(5000);

                // Config settings
                IWebElement configure = chrome.FindElementById("my-sagemcom-box-configure");
                configure.Click();

                Thread.Sleep(5000);

                // Maintenance button
                IWebElement maintenance = chrome.FindElementByLinkText("Vedligeholdelse");
                maintenance.Click();

                Thread.Sleep(10000);

                // Restart option
                IWebElement restart = chrome.FindElementById("restartGatewayTip");
                restart.Click();

                Thread.Sleep(5000);

                // Confirm restart
                IWebElement confirm = chrome.FindElementByCssSelector("button[ng-click='reboot()']");
                confirm.Click();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ROUTER REBOOTED SUCCESSFULLY");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}