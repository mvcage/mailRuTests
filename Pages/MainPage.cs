using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MailRuTests.Pages
{
    public class MainPage
    {
        By buttonSubmit = By.Id("mailbox:submit");
        By buttonLogout = By.Id("table.x-ph__auth a[id=PH_logoutLink]");
        By inputLogin = By.Id("mailbox:login");
        By wrapeEmailZone = By.Id("mailbox:domain");
        By inputPassword = By.Id("mailbox:password");
        
        public void ClickButtonSubmit(IWebDriver _browser)
        {
            IWebElement element = _browser.FindElement(this.buttonSubmit);
            element.Click();
        }
        public void ClickButtonLogout(IWebDriver _browser)
        {
            IWebElement element = _browser.FindElement(this.buttonLogout);
            element.Click();
        }
        public void FillLoginField(IWebDriver _browser, string _login)
        {
            IWebElement element = _browser.FindElement(this.inputLogin);
            element.SendKeys(_login);
        }
        public void FillPasswordField(IWebDriver _browser, string _password)
        {
            IWebElement element = _browser.FindElement(this.inputPassword);
            element.SendKeys(_password);
        }
        public void WrapeDomainsList(IWebDriver _browser)
        {
            IWebElement element = _browser.FindElement(this.wrapeEmailZone);
            element.Click();
        }
        public void SelectMailDomain(IWebDriver _browser, string _domain)
        {
            IWebElement element = _browser.FindElement(this.wrapeEmailZone);
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(_domain);
        }
        
    }
}
