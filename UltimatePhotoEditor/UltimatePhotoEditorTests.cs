using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UltimatePhotoEditor
{
    public class UltimatePhotoEditorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentificator = "35450PhotoCoolApps.UltimatePhotoEditor_61cxy7b35vdsg!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;  

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appIdentificator);
            this.driver = new WindowsDriver<WindowsElement> (new Uri(appiumServer), options);    


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

            Thread.Sleep(10000);          


            var jpgFormat = driver.FindElementByName("JPG");
            jpgFormat.Click();

            Thread.Sleep(3000);

            var saveImageButton = driver.FindElementByName("Save Image");
            saveImageButton.Click();

            Thread.Sleep(3000);

            Assert.That(createdPhoto + ".jpg", Is.Not.Null);
            
        }
    }
}