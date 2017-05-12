﻿using BartlettAreTheQAs.Models;
using BartlettAreTheQAs.Pages.Register_Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BartlettAreTheQAs.Pages.LogInPage;

namespace BartlettAreTheQAs
{
    [TestFixture]
    class BlogLoginPageTests
    {
        public IWebDriver driver;
        [SetUp]

        public void Initialized()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [TearDown]
        public void LogsandScreenshot()
        {
            // Don't close the driver because of TeamCity  
            //driver.Close();

        }

        [Test, Property("Priority", 2)]
        [Author("Tatyana Milanova")]
        public void NavigateToLogInPage()
        {         
             LoginPage LogPage = new LoginPage(driver);
             LogPage.NavigateTo();
             Assert.IsTrue(LogPage.LoginButton.Displayed);
        }

        [Test, Property("Priority", 2)]
        [Author("Tatyana Milanova")]
        public void LogInWithValidEmail()
        {
            LoginPage LogPage = new LoginPage(driver);
            LogPage.NavigateTo();
            var user = AccessExcelData.GetTestData("LogInValidEmail");
            LogPage.FillLoginForm(user);
            Assert.IsTrue(LogPage.ManageAccountButton.Displayed);
            
        }

        [Test, Property("Priority", 2)]
        [Author("Tatyana Milanova")]
        public void NavigateToManagePage()
        {
            LoginPage LogPage = new LoginPage(driver);
            LogPage.NavigateTo();
            var user = AccessExcelData.GetTestData("LogInValidEmail");
            LogPage.FillLoginForm(user);
            Assert.IsTrue(LogPage.ManageAccountButton.Displayed);

        }


        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void RegisterWihtoutEmail()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Register without mail");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertErrorMessage("The Email field is required.");

        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void RegisterAlreadyUsedEmail()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Register already used email");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertErrorMessage("The Email adress is already used");

        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void RegisterWithoutFullName()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Register without FullName");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertErrorMessage("The Full Name field is required.");

        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void RegisterWithoutPassword()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Register without Password");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertPasswordErrorMessage("The Password field is required.");

        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void RegisterWithoutComfirmPassword()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Register without Confirm password");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertPasswordErrorMessage("The Confirm Password field is required.");

        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void PasswordDoNotMatch()
        {
            RegisterPage RegPage = new RegisterPage(this.driver);
            RegPage.NavigateTo();
            var userex = AccessExcelData.GetTestData("Passwords do not match");
            RegPage.FillRegistrationForm(userex);
            RegPage.AssertPasswordErrorMessage("The password and confirmation password do not match.");

        }


    }
}
