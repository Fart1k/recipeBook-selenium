using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace RecipeBook_Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://techno.ee";
        }
    }
}
