using NUnit.Framework;
using OpenQA.Selenium;
using System;
using MailRuTests.Pages;

namespace MailRuTests
{
    [TestFixture]
    [Parallelizable]
    public class LoginTests
    {
        IWebDriver browser;
        MainPage mainPage = new MainPage();
        PersonalAreaPage personalAreaPage = new PersonalAreaPage();


        [SetUp]
        public void OpenBrowser()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = new System.TimeSpan(0, 0, 5);
            browser.Navigate().GoToUrl("https://mail.ru/");
        }
        [TearDown]
        public void CloseBroser()
        {
            browser.Quit();
        }

        [Test]
        public void CorrectLogin()
        {
            mainPage.FillLoginField(browser, "TestUser1950");
            mainPage.WrapeDomainsList(browser);
            mainPage.SelectMailDomain(browser, "@bk.ru");
            mainPage.FillPasswordField(browser, "zxASqw12");
            mainPage.ClickButtonSubmit(browser);
            personalAreaPage.ConfirmLogin(browser, "testuser1950@bk.ru");
        }
    }
}
