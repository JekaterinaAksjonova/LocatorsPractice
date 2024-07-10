using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;

namespace LocatorsPractice
{
    public class LocatorsTests

        
    {
        private IWebDriver driver;
        private string baseUrl = "C:\\Users\\katia\\OneDrive\\Рабочий стол\\QA\\FrontEndTestAutomation\\SeleniumWebDriver\\SimpleForm\\SimpleForm\\Locators.html";
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1200");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test]
        public void Locators_Verification()
        {
            var lastName = driver.FindElement(By.Id("lname"));
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Vega"));

            var newsLetterCheckBox = driver.FindElement(By.Name("newsletter"));
            Assert.IsFalse(newsLetterCheckBox.Selected);

            var anchorElement = driver.FindElement(By.TagName("a"));
            Assert.AreEqual(anchorElement.GetAttribute("text"), "Softuni Official Page");

            var infoElement = driver.FindElement(By.ClassName("information"));
            Assert.AreEqual("rgba(255, 255, 255, 1)", infoElement.GetCssValue("background-color"));

            var linkElement = driver.FindElement(By.LinkText("Softuni Official Page"));
            var hrefAttr = linkElement.GetAttribute("href");
            Assert.AreEqual(hrefAttr, "http://www.softuni.bg/");


            var linkElementFull = driver.FindElement(By.PartialLinkText("Softuni Official"));
            Assert.AreEqual(linkElementFull.Text, "Softuni Official Page");


            var firstNameCss = driver.FindElement(By.CssSelector("#fname"));
            var fNameValue = firstNameCss.GetAttribute("value");
            Assert.AreEqual(fNameValue, "Vincent");


            var fNameCssName = driver.FindElement(By.CssSelector("input[name='fname']"));
            Assert.AreEqual(fNameCssName.GetAttribute("value"), "Vincent");

            var submitBtn = driver.FindElement(By.CssSelector("input[class='button']"));
            Assert.AreEqual(submitBtn.GetAttribute("value"), "Submit");
            


            var phoneInput = driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));
            Assert.IsTrue(phoneInput.Displayed);


            var phoneInput2 = driver.FindElement(By.CssSelector("form div.additional-info > p > input[type='text']"));
            Assert.IsTrue(phoneInput2.Displayed);

            var radioBtn = driver.FindElement(By.XPath("/html/body/form/input[1]"));
            Assert.AreEqual(radioBtn.GetAttribute("value"), "m");

            var radioBtnRel = driver.FindElement(By.XPath("//input[@name='gender' and @value='m']"));
            Assert.AreEqual(radioBtnRel.GetAttribute("value"), "m");

            var lNameXP = driver.FindElement(By.XPath("//input[@name='lname']"));
            Assert.AreEqual(lNameXP.GetAttribute("value"), "Vega");

            var newsletterXP = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            Assert.AreEqual(newsletterXP.GetAttribute("type"), "checkbox");

            var submitBtnXP = driver.FindElement(By.XPath("//input[@class ='button']"));
            Assert.AreEqual(submitBtnXP.GetAttribute("value"), "Submit");

            var phoneXP = driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
            Assert.True(phoneXP.Displayed);
        }

        [Test]
        public void SubmitForm_RedirectsCorrectly()
        {
            var title = driver.FindElement(By.CssSelector("h2"));
            Assert.AreEqual(title.Text, "Contact Form");

            var maleBtn = driver.FindElement(By.XPath("//input[@value='m']"));
            maleBtn.Click();
            Assert.True(maleBtn.Selected);

            var fName = driver.FindElement(By.Id("fname"));
            fName.Clear();
            fName.SendKeys("Butch");
            Assert.AreEqual(fName.GetAttribute("value"), "Butch");

            var lName = driver.FindElement(By.Id("lname"));
            lName.Clear();
            lName.SendKeys("Coolidge");
            Assert.AreEqual(lName.GetAttribute("value"), "Coolidge");

            var additionalInfo = driver.FindElement(By.CssSelector("div.additional-info"));
            Assert.IsTrue(additionalInfo.Displayed);

            var phoneInput = driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
            phoneInput.SendKeys("0888999777");
            Assert.AreEqual(phoneInput.GetAttribute("value"), "0888999777");

            var newsLetterBtn = driver.FindElement(By.Name("newsletter"));
            newsLetterBtn.Click();
            Assert.IsTrue(newsLetterBtn.Selected);

            var submitBtn = driver.FindElement(By.CssSelector("input.button"));
            submitBtn.Click();

            var titleNextPage = driver.FindElement(By.CssSelector("h1"));
            Assert.AreEqual(titleNextPage.Text, "Thank You!");
        }
    }
}