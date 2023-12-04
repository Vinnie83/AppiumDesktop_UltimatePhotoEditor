using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;

namespace UltimatePhotoEditor
{
    public class UltimatePhotoEditorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentificator = "35450PhotoCoolApps.UltimatePhotoEditor_61cxy7b35vdsg!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        private const string appFolderPath = @"D:\Documents\Pictures\Ultimate Photo Editor";

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appIdentificator);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);


        }

        [TearDown]

        public void CloseApp()
        {
            driver.Quit();

        }

        [Test]
        public void Test_EditPhoto()
        {
            var createdPhoto = DateTime.Now.Ticks.ToString();
            string savedImageFileName = $"{createdPhoto}.jpg"; // Adjust the file extension if needed

            Thread.Sleep(6000);

            var galleryButton = driver.FindElementByName("GALLERY");
            galleryButton.Click();

            Thread.Sleep(6000);

            var fileName = driver.FindElementByClassName("Edit");
            fileName.Clear();
            fileName.SendKeys("IMG_20231111_104514");

            Thread.Sleep(6000);

            var openButton = driver.FindElementByClassName("Button");
            openButton.Click();

            Thread.Sleep(6000);

            var cropButton = driver.FindElementByName("CROP");
            cropButton.Click();

            var oneToOne = driver.FindElementByName("1 : 1");
            oneToOne.Click();

            var orientationButton = driver.FindElementByName("ORENTATION");
            orientationButton.Click();

            var horizontalFlipButton = driver.FindElementByName("Horizontal Flip");
            horizontalFlipButton.Click();

            var effectButton = driver.FindElementByName("EFFECT");
            effectButton.Click();

            var effectImage = driver.FindElementByAccessibilityId("EffectGridView");
            effectImage.Click();

            var okImage = driver.FindElementByAccessibilityId("OkImg");
            okImage.Click();

            //var cancelImage = driver.FindElementByName("Cancel");
            //cancelImage.Click();    

            Thread.Sleep(10000);

            var newOkImage = driver.FindElementByAccessibilityId("OkImg");
            newOkImage.Click();

            Thread.Sleep(10000);

            var txtFileName = driver.FindElementByAccessibilityId("txtFilename");
            txtFileName.Clear();
            txtFileName.SendKeys(createdPhoto);

            Thread.Sleep(6000);

            var folderPath = driver.FindElementByName("Popup");
            folderPath.Click();

            Thread.Sleep(3000);


            var jpgFormat = driver.FindElementByName("JPG");
            jpgFormat.Click();

            Thread.Sleep(3000);

            // Assuming the main window is already located
            var mainWindow = driver.FindElementByClassName("ApplicationFrameWindow");

            // Locate the child element within the main window that is unique to the popup
            var popupTitle = mainWindow.FindElementByXPath("//Window[@ClassName='Popup']/Text[@ClassName='TextBlock' and @Name='Save Image']");

            // Assuming the main window is already located
            mainWindow = driver.FindElementByClassName("ApplicationFrameWindow");

            // Locate the "Save Image" button within the main window
            var saveImageButton = mainWindow.FindElementByXPath("//Window[@ClassName='Popup']/Text[@Name='Save Image' and @AutomationId='TxtOffToggle']");
            saveImageButton.Click();

            Thread.Sleep(3000);

            var okButtonFinal = driver.FindElementByAccessibilityId("SecondryBtnText");
            okButtonFinal.Click();


            Thread.Sleep(5000);

            string fullPathToSavedImage = Path.Combine(appFolderPath, savedImageFileName);

            Thread.Sleep(3000);

            // Assert that the file exists
            Assert.IsTrue(File.Exists(fullPathToSavedImage), $"The saved image file '{savedImageFileName} was found in the app folder.");
        }

    }  
           
}