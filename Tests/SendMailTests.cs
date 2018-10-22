using NUnit.Framework;
using OpenQA.Selenium;
using System;
using MailRuTests.Pages;

namespace MailRuTests
{
    [TestFixture]
    [Parallelizable]
    public class SendMaiTests
    {
        IWebDriver browser;
        MainPage mainPage = new MainPage();
        PersonalAreaPage personalAreaPage = new PersonalAreaPage();

        [SetUp]
        public void LoginUser()
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = new System.TimeSpan(0, 0, 8);
            browser.Navigate().GoToUrl("https://mail.ru/");

            mainPage.FillLoginField(browser, "TestUser1950");
            mainPage.WrapeDomainsList(browser);
            mainPage.SelectMailDomain(browser, "@bk.ru");
            mainPage.FillPasswordField(browser, "zxASqw12");
            mainPage.ClickButtonSubmit(browser);
        }
        
        [TearDown]
        public void CloseBroser()
        {
            browser.Quit();
        }

        [Test]
        public void SendCommonEmail()
        {
            personalAreaPage.ClickButtonWriteLetter(browser);
            personalAreaPage.InputRecipientMail(browser, "JohnDoe@p33.org");
            personalAreaPage.InputletterTopic(browser, "Lorem ipsum");
            personalAreaPage.InputLetterContent(browser, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem...");
            personalAreaPage.ClickButtonSendEail(browser);
            personalAreaPage.ConfirmationOfSending(browser, "JohnDoe <johndoe@p33.org>");
        }

        [Test]
        public void SendEmailWithoutRecipient()
        {
            personalAreaPage.ClickButtonWriteLetter(browser);
            personalAreaPage.InputletterTopic(browser, "Lorem ipsum");
            personalAreaPage.InputLetterContent(browser, "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem...");
            personalAreaPage.ClickButtonSendEail(browser);
            personalAreaPage.AllertWindow(browser, "Не указан адрес получателя");
        }
    }
}