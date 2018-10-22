
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace MailRuTests.Pages
{
    class PersonalAreaPage
    {
        By buttonWriteLetter = By.CssSelector("#b-toolbar__left > div > div > div.b-toolbar__group.b-toolbar__group_left > div > a");
        By buttonSendEmail = By.CssSelector("#b-toolbar__right > div:nth-child(3) > div > div:nth-child(2) > div.b-toolbar__item.b-toolbar__item_.b-toolbar__item_false > div > span");
        By letterRecipient = By.CssSelector("div.compose-head__row-wrapper[data-label=compose_to] div[data-bem=label-input]");
        By letterTopic = By.CssSelector("div.compose-head__row-wrapper[data-label=Subject] div.compose-head__field");
        By letterInputField = By.CssSelector("div.compose__editor div.compose__editor__frame");
        By recipient = By.CssSelector("#b-compose__sent > div > div:nth-child(2) > div:nth-child(1) > span");
        By userNameElement = By.Id("table.x-ph__auth i[id=PH_user-email]");

        public void ClickButtonWriteLetter(IWebDriver _browser)
        {
            IWebElement element = _browser.FindElement(this.buttonWriteLetter);
            element.Click();
        }

        public void ClickButtonSendEail(IWebDriver _browser)
        {
            IWebElement element = _browser.FindElement(this.buttonSendEmail);
            element.Click();
        }
        public void InputRecipientMail(IWebDriver _browser, string _recipientMail)
        {
            Actions action = new Actions(_browser);
            IWebElement element = _browser.FindElement(this.letterRecipient);
            element.Click();
            action.MoveToElement(element);
            action.SendKeys(_recipientMail);
            action.Build().Perform();
        }

        public void InputletterTopic(IWebDriver _browser, string _letterTopic)
        {
            Actions action = new Actions(_browser);
            IWebElement element = _browser.FindElement(this.letterTopic);
            
            action.MoveToElement(element, 0, 0);
            action.Click(element);
            action.SendKeys(element, _letterTopic);
            action.Build().Perform();
        }

        public void InputLetterContent(IWebDriver _browser, string _letterContent)
        {
            Actions action = new Actions(_browser);
            IWebElement element = _browser.FindElement(this.letterInputField);
            
            action.MoveToElement(element);
            action.Click();
            action.SendKeys( "\r\n" +_letterContent);
            action.Build().Perform();
        }

        public void ConfirmationOfSending(IWebDriver _browser, string _expectedRecipient)
        {
            IWebElement element = _browser.FindElement(this.recipient);
            string recipientMail = element.Text;
            Assert.IsTrue(element.Text.Equals(_expectedRecipient), "The recipient's address does not match");
        }

        public void AllertWindow(IWebDriver _browser, string _expectedTextAlert)
        {
            IAlert alert = _browser.SwitchTo().Alert();
            string alertText = alert.Text;
            Assert.IsTrue(alertText.Equals(_expectedTextAlert), "The text of warning is not correct " + alertText);

        }

        public void ConfirmLogin(IWebDriver _browser, string userEmail)
        {
            System.Threading.Thread.Sleep(2000);
            string url = _browser.Url;
            //IWebElement element = _browser.FindElement(this.userNameElement);
            //Assert.IsTrue(element.Text.Equals(userEmail), "Expected email addres is wrong " + userEmail);
            Assert.IsTrue(url.Equals("https://e.mail.ru/messages/inbox/?back=1"), url);
        }
    }
}
