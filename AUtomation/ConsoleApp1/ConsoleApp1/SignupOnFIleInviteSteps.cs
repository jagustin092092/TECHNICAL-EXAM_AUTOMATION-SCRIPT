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
    [Binding]
    public class FileInviteSteps //: IDisposable
    {

        private ChromeDriver chromeDriver;
        public FileInviteSteps() => chromeDriver = new ChromeDriver();




        [Given(@"I am on FileInvite page")]
        public void GivenIAmOnFileInvitePage()
        {
            chromeDriver.Navigate().GoToUrl("https://app.fileinvite.com/email-register");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("fileinvite"));


        }

        [When(@"I enter (.*) as valid email address")]
        public void WhenIEnterEmailAsValidEmailAddress(String emailAddress)
        {
            chromeDriver.FindElement(By.Id("email-registration-email-input")).SendKeys(emailAddress);
            //string typedEmailAddress = chromeDriver.FindElement(By.Id("email-registration-email-input")).GetAttribute(emailAddress);
        }


        [When(@"I click on Sign Up button")]
        public void WhenIClickOnSignUpButton()
        {
            chromeDriver.FindElement(By.Id("email-registration-btn")).Click();
        }

        [Then(@"I am able to sign up on FIleInvite")]
        public void ThenIAmAbleToSignUpOnFIleInvite(Table table)
        {
            RegistrationDetails details = table.CreateInstance<RegistrationDetails>();

            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var textPresentOnUI = chromeDriver.FindElement(By.CssSelector("#create_persons_registration > div > div.modal-header > h5")).Text;
            Assert.IsTrue(textPresentOnUI.Equals("Welcome to FileInvite"));
            Console.WriteLine("Page Header is " + textPresentOnUI);


            chromeDriver.FindElement(By.Id("first-name-input")).SendKeys(details.FirstName);
            chromeDriver.FindElement(By.Id("last-name-input")).SendKeys(details.LastName);
            chromeDriver.FindElement(By.Id("company-input")).SendKeys(details.Company);
            chromeDriver.FindElement(By.Id("password-input")).SendKeys(details.Password);
            chromeDriver.FindElement(By.CssSelector("#create_persons_registration > div > div.modal-body > div > div:nth-child(4) > div > input[type=checkbox]")).Click();
            chromeDriver.FindElement(By.CssSelector("#create_persons_registration > div > div.modal-footer > button")).Click();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            var profileEmail = chromeDriver.FindElement(By.XPath("//*[@id='main-app']/div[1]/div/header/nav/div[2]/ul/li[2]/a")).Text;
            var emailAddress = "qatestjsa4@yopmail.com";
            Assert.IsTrue(profileEmail.Equals(emailAddress));
            Console.WriteLine("Profile Email is " + profileEmail);

        }

        [Given(@"I navigate on fileinvite signin page")]
        public void GivenINavigateOnFileinviteSigninPage()
        {
            chromeDriver.Navigate().GoToUrl("https://app.fileinvite.com/login");
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("fileinvite"));
        }

        [Given(@"I sign in using correct email address and password")]
        public void GivenISignInUsingCorrectEmailAddressAndPassword(Table table)
        {
            LoginDetails details = table.CreateInstance<LoginDetails>();
            chromeDriver.FindElement(By.Id("login-username-input")).SendKeys(details.EmailAddress);
            chromeDriver.FindElement(By.Id("login-password-input")).SendKeys(details.Password);
            chromeDriver.FindElement(By.Id("login-btn")).Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [When(@"I click Create Person button from Contacts form")]
        public void WhenIClickCreatePersonButtonFromContactsForm()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main-app']/div[1]/div/aside/section/ul/li[5]/a/span[1]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/div[1]/a"))).Click();
        } 

        [When(@"I enter Contact Details")]
        public void WhenIEnterContactDetails(Table table)
        {
            var details = table.CreateInstance<ContactDetails>();
            chromeDriver.FindElement(By.CssSelector("#user-firstname-input")).SendKeys(details.FirstName);
            chromeDriver.FindElement(By.CssSelector("#user-lastname-input")).SendKeys(details.LastName);
            chromeDriver.FindElement(By.CssSelector("#contact-company-dropdown")).SendKeys(details.Company);
            chromeDriver.FindElement(By.CssSelector("#add-contact-email-type-dropdown-0")).SendKeys(details.EmailType);
            chromeDriver.FindElement(By.CssSelector("#add-contact-email-address-input-0")).SendKeys(details.Email);
            chromeDriver.FindElement(By.CssSelector("#add-contact-phone-type-dropdown-0")).SendKeys(details.PhoneType);
            chromeDriver.FindElement(By.CssSelector("#add-contact-phone-number-input-0")).SendKeys(details.Mobile);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-type-dropdown-0")).SendKeys(details.AddressType);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-line1-input-0")).SendKeys(details.Address1);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-line2-input-0")).SendKeys(details.Address2);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-city-input-0")).SendKeys(details.City);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-state-input-0")).SendKeys(details.State);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-country-dropdown-0")).SendKeys(details.Country);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-zipcode-input-0")).SendKeys(details.ZipCode);


        }

        [When(@"I click Save Contact button")]
        public void WhenIClickSaveContactButton()
        {


            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-user-submit-btn"))).Click();

        }

        [Then(@"I am able to successfully create a new Contact with correct details")]
        public void ThenIAmAbleToSuccessfullyCreateANewContactWithCorrectDetails(Table table)
        {
            

            string ContactName = "FirstJSA4E";
         

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            var SearchField = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#search-form")));
            SearchField.SendKeys(ContactName);

            var editIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div/div/div/div/div[7]/div/a[2]")));
            editIcon.Click();

            var details = table.CreateInstance<ContactDetails>();
            
            var first_Name = chromeDriver.FindElement(By.CssSelector("#user-firstname-input")).GetAttribute("value");

            Assert.IsTrue(details.FirstName.Equals(first_Name));
            Console.WriteLine("ExpectedName " + details.FirstName);
            Console.WriteLine("ActualName " + first_Name);
            var last_name = chromeDriver.FindElement(By.CssSelector("#user-lastname-input")).GetAttribute("value");
            Assert.IsTrue(details.LastName.Equals(last_name));
            Console.WriteLine("ExpectedName " + details.LastName);
            Console.WriteLine("ActualName " + last_name);
            var email = chromeDriver.FindElement(By.CssSelector("#add-contact-email-address-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Email.Equals(email));
            var phone_number = chromeDriver.FindElement(By.CssSelector("#add-contact-phone-number-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Mobile.Equals(phone_number));
            var address_1 = chromeDriver.FindElement(By.CssSelector("#add-contact-address-line1-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Address1.Equals(address_1));
            var address_2 = chromeDriver.FindElement(By.CssSelector("#add-contact-address-line2-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Address2.Equals(address_2));
            var city = chromeDriver.FindElement(By.CssSelector("#add-contact-address-city-input-0")).GetAttribute("value");
            Assert.IsTrue(details.City.Equals(city));
            var state = chromeDriver.FindElement(By.CssSelector("#add-contact-address-state-input-0")).GetAttribute("value");
            Assert.IsTrue(details.State.Equals(state));
            var zipcode = chromeDriver.FindElement(By.CssSelector("#add-contact-address-zipcode-input-0")).GetAttribute("value");
            Assert.IsTrue(details.ZipCode.Equals(zipcode));

        }
        [When(@"I click Companies button from Contacts form")]
        public void WhenIClickCompaniesButtonFromContactsForm()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='main-app']/div[1]/div/aside/section/ul/li[5]/a/span[1]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app > div > ul > li:nth-child(2) > a"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app > div > div > div.data-table__action-bar > a"))).Click();

        }
        [When(@"I enter Company Details")]
        public void WhenIEnterCompanyDetails(Table table)
        {
            var details = table.CreateInstance<CompanyInformation>();
            chromeDriver.FindElement(By.CssSelector("#contacts-company-name-input")).SendKeys(details.Name);
            chromeDriver.FindElement(By.CssSelector("#contacts-company-website--input")).SendKeys(details.Website);
            chromeDriver.FindElement(By.CssSelector("#add-contact-email-type-dropdown-0")).SendKeys(details.EmailType);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-email-address-input-0")).SendKeys(details.Email);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-phone-type-dropdown-0")).SendKeys(details.PhoneType);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-phone-number-input-0")).SendKeys(details.Number);
            chromeDriver.FindElement(By.CssSelector("#add-contact-address-type-dropdown-0")).SendKeys(details.AddressType);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-line1-input-0")).SendKeys(details.Address1);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-line2-input-0")).SendKeys(details.Address2);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-city-input-0")).SendKeys(details.City);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-state-input-0")).SendKeys(details.State);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-country-dropdown-0")).SendKeys(details.Country);
            chromeDriver.FindElement(By.CssSelector("#add-contacts-company-address-zipcode-input-0")).SendKeys(details.ZipCode);

        }
        [When(@"I click Save Company button")]
        public void WhenIClickSaveCompanyButton()
        {
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#add-contacts-company-submit-btn"))).Click();


        }


        [Then(@"I am able to successfully create a new Company with correct details")]
        public void ThenIAmAbleToSuccessfullyCreateANewCompanyWithCorrectDetails(Table table)
        {
            string CompanyName = "Company JSA4E";


            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30));
            var SearchField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search-form")));
            SearchField.SendKeys(CompanyName);

            var editIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div/div/div/div/div[6]/div/a[2]")));
            editIcon.Click();

            var details = table.CreateInstance<CompanyInformation>();

            var name = chromeDriver.FindElement(By.CssSelector("#contacts-company-name-input")).GetAttribute("value");
            Assert.IsTrue(details.Name.Equals(name));
            Console.WriteLine("Expected " + details.Name);
            Console.WriteLine("Actual " + name);

            var website = chromeDriver.FindElement(By.CssSelector("#contacts-company-website--input")).GetAttribute("value");
            Assert.IsTrue(details.Website.Equals(website));
            var email = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-email-address-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Email.Equals(email));
            var phone_number = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-phone-number-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Number.Equals(phone_number));
            var address_1 = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-address-line1-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Address1.Equals(address_1));
            var address_2 = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-address-line2-input-0")).GetAttribute("value");
            Assert.IsTrue(details.Address2.Equals(address_2));
            var city = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-address-city-input-0")).GetAttribute("value");
            Assert.IsTrue(details.City.Equals(city));
            var state = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-address-state-input-0")).GetAttribute("value");
            Assert.IsTrue(details.State.Equals(state));
            var zipcode = chromeDriver.FindElement(By.CssSelector("#edit-contacts-company-address-zipcode-input-0")).GetAttribute("value");
            Assert.IsTrue(details.ZipCode.Equals(zipcode));

        }
        [When(@"I click Create New Invite button")]
        public void WhenIClickCreateNewInviteButton()
        {
            chromeDriver.FindElement(By.CssSelector("#main-app > div:nth-child(2) > div > header > nav > div.navbar-custom-menu > ul > li:nth-child(1) > a")).Click();
            
        
        }
        [When(@"I use existing template")]
        public void WhenIUseExistingTemplate()
        {
         
            
            
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("load-template-btn"))).Click();
            chromeDriver.FindElement(By.XPath("//*[@id='loadTemplateModal']/div/div/div[2]/div/div[2]/div[1]/div[2]/ul/li[1]/a")).Click();

            var identificationTemplateBtn = chromeDriver.FindElement(By.XPath("//*[@id='0']/div[2]"));
            identificationTemplateBtn.Click();

            var replaceInviteBtn = chromeDriver.FindElement(By.CssSelector("#replace-template-btn"));
            replaceInviteBtn.Click();
            
        }

        [When(@"I select (.*) as Due Date")]
        public void WhenISelect_DueDate()
        {
            var dueDate = chromeDriver.FindElement(By.Id("duedate"));
            dueDate.Click();
            
        }

        [When(@"I search for (.*) as an existing Contact")]
        public void WhenISearchFor_AsAnExistingContact(string Contact)
        {
            var searchContact = chromeDriver.FindElement(By.CssSelector("#edit-invite-form > div.box.box-solid.invite-setup-box > div.box-body > div > div:nth-child(2) > div.row.contact-create-controls > div.col-lg-7.col-8 > div > div > span > input.form-control.contact-search.tt-input"));
            searchContact.SendKeys(Contact);
        }

        [When(@"I select Due Date")]
        public void WhenISelectDueDate(string Date)
        {
            Date = "2021-04-22";
            var dueDate = chromeDriver.FindElement(By.CssSelector("#main-app > div.datepicker.datepicker-dropdown.dropdown-menu.datepicker-orient-right.datepicker-orient-bottom > div.datepicker-months > table > tbody > tr > td > span:nth-child(9)"));
            dueDate.Click(); 
        }

    }




}






        //public void Dispose()
        //{
        //    if (chromeDriver != null)
        //    {
        //        chromeDriver.Dispose();
        //        chromeDriver = null;
        //    }
        //}
//    }
//}
