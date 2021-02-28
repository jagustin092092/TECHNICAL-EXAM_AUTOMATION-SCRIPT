using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace ConsoleApp1
{
    public class SeleniumCustomMethods
    {

        public static void EnterText(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "id")
                driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);
            if (elementtype == "csselector")
                driver.FindElement(By.CssSelector(element)).SendKeys(value);
            if (elementtype == "XPath")
                driver.FindElement(By.XPath(element)).SendKeys(value);
        }

        public static void click(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "id")
                driver.FindElement(By.Id(element)).Click();
            if (elementtype == "Name")
                driver.FindElement(By.Name(element)).Click();
            if (elementtype == "csselector")
                driver.FindElement(By.CssSelector(element)).Click();
            if (elementtype == "XPath")
                driver.FindElement(By.XPath(element)).Click();
        }
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype)
        {
            //SelectElement selectElement = new SelectElement
        }
        public static string GetText(IWebDriver driver, string element, string elementtype)
        {
            if (elementtype == "id")
                return driver.FindElement(By.Id(element)).Text;
            if (elementtype == "cssselector")
                return driver.FindElement(By.CssSelector(element)).Text;
            if (elementtype == "xpath")
                return driver.FindElement(By.XPath(element)).Text;
            else return String.Empty;
        }
    }
}

