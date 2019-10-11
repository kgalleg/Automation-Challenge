using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace RPA
{
    class Program
    {
        static void Main(string[] args)
        {
            // This instantiates the Chrom WebDriver, and assigns it a variable named driver.
            IWebDriver driver = new ChromeDriver();

            // This navigates to the page with WebDriver.
            driver.Navigate().GoToUrl("https://hpadevtest.azurewebsites.net/");

            //This one works too:
            // driver.Url=("https://hpadevtest.azurewebsites.net/");


            //Locating elements in WebDriver can be done on the WebDriver instance itself or on a WebElement. Each of the language bindings exposes a “Find Element” and “Find Elements” method. The former returns a WebElement object matching the query, and throws an exception if such an element cannot be found. The latter returns a list of WebElements, possibly empty if no DOM elements match the query.
            //The “Find” methods take a locator or query object called “By”. “By” strategies are listed below : BY ID, BY CLASS NAME, BY TAG NAMEk BY NAME, BY Link Text/partial link text, by css, by xpath, using JS


            //Step 1 -- Click me with the mouse. | Found the id of Step 1 box while inspecting the HTML of the webpage called BoxHeader1 and used the Click command.
            driver.FindElement(By.Id("BoxHeader1")).Click();

            //Simple alerts just have a OK button on them. They are mainly used to display some information to the user. Important point to note is that we can switch from main window to an alert using the driver.SwitchTo().Alert().
            // Below: Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Accept()' is used to accept the alert '(click on the Ok button)' as soon as the pop up window appears.
            simpleAlert.Accept();


            //Step 2 -- Focus/Click on the box and send TAB key. | Found the id of Step 2 box by inspecting the HTML code of the webpage called Box3 and used the Click command to "set focus on it"
            driver.FindElement(By.Id("Box3")).Click();

            //SendKeys simulates typing text into the element. Keys is used for non-text keys and pass it to the SendKeys Method. Tab represents the Tab key.
            driver.FindElement(By.Id("Box3")).SendKeys(Keys.Tab);

            //this accepts the alert like in line 41
            simpleAlert.Accept();


            //step 3 -- Selecting radio button option 1 or 2. I started out with finding element by CssSelector and didn't get that to work because as I tested the application I found out that the option needed to be selected changes.  Sometimes it asks to select option 1 and sometimes it asks to select option 2, so I had to change thinking.

            //I left this non-working code here so you can see what I originally did.
            // driver.FindElement(By.CssSelector("input[value=2]")).Click();
            // driver.FindElement(By.CssSelector("input[name='option'][value='2'][type='radio']")).Click();
            // simpleAlert.Accept();

            //optionval is the id of the integer(text) that changes the option number randomly, that's why I choose this to find the element by that id name.
            //This finds the text that has the id of optionVal
            var optionText = driver.FindElement(By.Id("optionVal")).Text;


            //This finds the xpath with type=radio that includes the text from optionText and it clicks on that radio button.
            //XPath contains the path of the element situated at the web page.
            //Standard syntax for creating XPath is. Xpath=//tagname[@attribute='value']
            IWebElement optionRadioButton = driver.FindElement(By.XPath($"//*[@type='radio'][{optionText}]"));
            optionRadioButton.Click();

            //accepts the alert
            simpleAlert.Accept();

            //step 4 -- Selecting the text/word that the program asks for. selectionVal is the id of the text that randomly changes everytime a "user" comes to the website - therefore, I need to find the text first.
             var dropDownText = driver.FindElement(By.Id("selectionVal")).Text;

            //The 'Select' class in Selenium WebDriver is used for selecting and deselecting option in a dropdown. The objects of Select type can be initialized by passing the dropdown webElement as parameter to its constructor.
            SelectElement dropDownSelection = new SelectElement(driver.FindElement(By.XPath("//select")));
            dropDownSelection.SelectByValue($"{dropDownText}");

            //accepts the alert
            simpleAlert.Accept();

            //step 5 -- Complete the form - use the place-holder text as values and submit. I found it easiest to FindElement by CssSelector since they all had different placeholders except for when I got to country number two that had USA as a placeholder/text. My thought process on that is in line 116.

            //found element by CssSelector
            var formDateOne = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2017-05-04']"));

            //This is getting the text that is in "placeholder" and sending that exact same text to that element location.
            String formDateOneText = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2017-05-04']")).GetAttribute("placeholder");
            formDateOne.SendKeys(formDateOneText);

            var formCityOne = driver.FindElement(By.CssSelector("input[type='text'][id='formCity'][placeholder='Nashville']"));
            String formCityOneText = driver.FindElement(By.CssSelector("input[type='text'][id='formCity'][placeholder='Nashville']")).GetAttribute("placeholder");
            formCityOne.SendKeys(formCityOneText);

            var formStateOne = driver.FindElement(By.CssSelector("input[type='text'][id='formState'][placeholder='Tennessee']"));
            String formStateOneText = driver.FindElement(By.CssSelector("input[type='text'][id='formState'][placeholder='Tennessee']")).GetAttribute("placeholder");
            formStateOne.SendKeys(formStateOneText);

            var formCountryOne = driver.FindElement(By.CssSelector("input[type='text'][id='formCountry'][placeholder='USA']"));
            String formCountryOneText = driver.FindElement(By.CssSelector("input[type='text'][id='formCountry'][placeholder='USA']")).GetAttribute("placeholder");
            formCountryOne.SendKeys(formCountryOneText);

            var formDateTwo = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2009-08-26']"));
            String formDateTwoText = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2009-08-26']")).GetAttribute("placeholder");
            formDateTwo.SendKeys(formDateTwoText);

             var formCityTwo = driver.FindElement(By.CssSelector("input[type='text'][id='formCity'][placeholder='Seattle']"));
            String formCityTwoText = driver.FindElement(By.CssSelector("input[type='text'][id='formCity'][placeholder='Seattle']")).GetAttribute("placeholder");
            formCityTwo.SendKeys(formCityTwoText);

            var formStateTwo = driver.FindElement(By.CssSelector("input[type='text'][id='formState'][placeholder='Washington']"));
            String formStateTwoText = driver.FindElement(By.CssSelector("input[type='text'][id='formState'][placeholder='Washington']")).GetAttribute("placeholder");
            formStateTwo.SendKeys(formStateTwoText);

            //When I got to the second country, the placeholder/text was USA, the same as the first country, so I found that FindingElement by CSS Selector would not work, so I choose to FindElement by Xpath and found that by  clicking on the HTML line where the formCountry if was and going to copy, copy full xpath, and this worked.
            var formCountryTwo = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/center[1]/div[1]/div[1]/div[1]/center[1]/table[1]/tbody[1]/tr[8]/td[1]/input[1]"));
            String formCountryTwoText = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/center[1]/div[1]/div[1]/div[1]/center[1]/table[1]/tbody[1]/tr[8]/td[1]/input[1]")).GetAttribute("placeholder");
            formCountryTwo.SendKeys(formCountryTwoText);

            var formDateThree = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2007-10-10']"));
            String formDateThreeText = driver.FindElement(By.CssSelector("input[type='text'][id='formDate'][placeholder='2007-10-10']")).GetAttribute("placeholder");
            formDateThree.SendKeys(formDateThreeText);

            //finding submit button element
            var submitButton = driver.FindElement(By.XPath("/html/body/div[5]/center/div/div/div[1]/center/table/tbody/tr[10]/td/center/button"));

            //clicking on submit button
            submitButton.Click();

            //accepts the alert
            simpleAlert.Accept();


        }
    }
}


