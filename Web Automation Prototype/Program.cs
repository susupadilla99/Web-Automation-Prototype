using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Web_Automation_Prototype
{
    internal class Program
    {
        const String ILEARN_URL = "https://ilearn.mq.edu.au/";
        
        
        static IWebDriver driver;
        static String openIlearnUrl = "";
        static String[] units = { "COMP1010", "COMP1350", "COMP2100" };
        static int session = 2;
        static int year = 2023;

        /* Main structural functions */

        static void readInputs()
        {
            // Gather Session details
            int inputValue = 0;
            while (inputValue < 1 || inputValue > 3)
            {
                Console.Write("Which session is this? ( 1 / 2 / 3 ): ");
                String inputString = Console.ReadLine();
                Int32.TryParse(inputString, out inputValue);
            }
            session = inputValue;

            // Gather Year details
            inputValue = 0;
            while (inputValue < 1000 || inputValue > 9999)
            {
                Console.Write("Which year is it? ( e.g: 2023 ): ");
                String inputString = Console.ReadLine();
                Int32.TryParse(inputString, out inputValue);
            }
            year = inputValue;
        }

        static void initialiseBrowser()
        {
            // Create a new Chrome browser
            Console.WriteLine("Opening Chrome...");
            driver = new ChromeDriver();

            // Navigate to iLearn login page
            Console.WriteLine("Opening Login Page...");
            driver.Navigate().GoToUrl(ILEARN_URL);

            // Wait for user input
            Console.WriteLine();
            Console.WriteLine("Please login to your MQ staff account. Press ENTER after you've successfully logged in.");
            Console.WriteLine("Pren ENTER to continue...");
            Console.ReadLine();
            Console.WriteLine("\n");
        }

        static void navigateOpenIlearn()
        {
            Console.WriteLine("Navigating to Open Ilearn");

            // Expand right tab if necessary
            IWebElement rightDrawer = driver.FindElement(By.ClassName("drawer-right"));
            if (rightDrawer.GetCssValue("visibility") == "hidden")
                driver.FindElement(By.CssSelector(".drawer-toggles .drawer-toggler button")).Click();

            // Wait until elements are interactible
            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(drv => drv.FindElement(By.ClassName("tftextinput")) );
            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            // Navigate to openIlearn
            driver.FindElement(By.ClassName("tftextinput")).SendKeys("COMP1000");
            driver.FindElement(By.ClassName("tfbutton")).Submit();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            openIlearnUrl = driver.Url;
        }

        static void gotoUnit(String unit)
        {
            // Search for unit on openIlearn
            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(drv => drv.FindElement(By.ClassName("simplesearchform"))); // Wait until loaded
            IWebElement searchBar =  driver.FindElement(By.CssSelector("#region-main .form-control"));
            searchBar.Clear();
            searchBar.SendKeys(unit);
            driver.FindElement(By.CssSelector("#region-main .search-icon")).Submit();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Find courses container element
            new WebDriverWait(driver, TimeSpan.FromSeconds(1)).Until(drv => drv.FindElement(By.ClassName("courses"))); // Wait until loaded
            IWebElement coursesContainer = driver.FindElement(By.ClassName("courses"));
            ReadOnlyCollection<IWebElement> courseList = coursesContainer.FindElements(By.ClassName("coursebox"));

            // Iterate and validate each courses
            foreach(IWebElement course in courseList )
                if ( validateUnit(course) ) {
                    course.FindElement(By.ClassName("aalink")).Click(); // Navigate to valid link
                    break;
                }

            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        static Boolean gotoAnnouncement()
        {
            Console.WriteLine("Checking all links in page for Announcements\n\n");

            // Gather all link in the web page
            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.ClassName("aalink"));

            // Check all links to see if they are announcements
            foreach(IWebElement link in links )
            {
                 if (validateLink(link))
                {
                    link.Click();
                    return true;
                }
            }

            return false;
        }

        static void postContent()
        {
            // Click on "Add discussion topic"
            driver.FindElement(By.CssSelector(".navitem .btn[href=\"#collapseAddForm\"]")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));

            // Clear textboxes
            driver.FindElement(By.Id("id_subject")).Clear();
            driver.FindElement(By.Id("id_messageeditable")).Clear();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Send message to textboxes
            driver.FindElement(By.Id("id_subject")).SendKeys("Welcome from FSE Student Experience Team");
            driver.FindElement(By.Id("id_messageeditable")).SendKeys("Hi, this is a test message. If you do see this somehow, please ignore it. Thank you!");
            Thread.Sleep(TimeSpan.FromSeconds(4));

            // Press Cancel
            driver.FindElement(By.Id("id_cancelbtn")).Click();
        }

        /* Helper Functions */
        static Boolean validateUnit(IWebElement course)
        {
            String category = "[Empty]";

            try
            {
                category = course.FindElement(By.CssSelector(".coursecat a")).Text;
                if (category == $"Session {session}, {year}")
                    return true;
            }
            catch (NoSuchElementException ex)
            {
                // Do nothing
            }

            return false;
        }

        static Boolean validateLink(IWebElement link)
        {
            String linkTitle = "[Empty]";

            try
            {
                linkTitle = link.FindElement(By.ClassName("instancename")).GetDomProperty("innerText");
                String cleanedLink = linkTitle.Normalize().ToLower();
                if (cleanedLink.Contains("announcements"))
                    return true;
            }
            catch (Exception ex)
            {
                // Do nothing
            }

            return false;
      
        }

        static void testFunction()
        {
            // Gather all link in the web page
            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.ClassName("aalink"));

            // Check all links to see if they are announcements
            foreach (IWebElement link in links)
            {
                try
                {
                    IWebElement spanEl = link.FindElement(By.ClassName("instancename"));
                    String clean = spanEl.GetDomProperty("innerText").Normalize().ToLower();
                    Console.WriteLine(clean);
                }
                catch (Exception ex) { }
            }

        }

        /* Main */

        static void Main(string[] args)
        {
            readInputs();

            initialiseBrowser();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            navigateOpenIlearn();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            foreach (String unit in units)
            {
                Console.WriteLine($"Examining {unit}:");

                gotoUnit(unit);
                Thread.Sleep(TimeSpan.FromSeconds(1));

                gotoAnnouncement();
                Thread.Sleep(TimeSpan.FromSeconds(2));

                postContent();
                Thread.Sleep(TimeSpan.FromSeconds(4));

                driver.Navigate().GoToUrl(openIlearnUrl);
            }

            //gotoUnit("COMP3000");
            //testFunction();

            driver.Navigate().GoToUrl(ILEARN_URL);
            Console.WriteLine("All done!");


            // Exit program
            Thread.Sleep(TimeSpan.FromSeconds(20));
            driver.Quit();

        }
    }
}
