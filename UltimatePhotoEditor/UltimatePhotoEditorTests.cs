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
            Assert.Pass();
        }
    }
}