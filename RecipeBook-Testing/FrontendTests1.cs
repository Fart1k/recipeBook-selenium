using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace RecipeBook_Testing
{
    [TestCaseOrderer("RecipeBook_Testing.PriorityOrderer", "RecipeBook_Testing")]
    public class FrontendTests1
    {
        public string[] DataOfRecipe1 { get; set; } = {
            Guid.NewGuid().ToString(), 
            "SeleniumDescription", 
            "111111", 
            "", 
            "http://google.com" 
        };
        public string[] DataOfRecipe2 { get; set; } = {
            "", 
            "NewDescription", 
            "222222", 
            "", 
            "http://google.com" 
        };

        [Fact] //Siin on test
        [Order(1)] //Järjekorranumber
        public void Should_NavigateToCreate_AddRecipe_WithCorrectData()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://localhost:5173";

            IWebElement navigateToRecipes = driver.FindElement(By.Id("RL_Recipes"));
            navigateToRecipes.Click();

            IWebElement NavigateToCreateRecipe = driver.FindElement(By.Id("CreateGame"));
            NavigateToCreateRecipe.Click();

            //Tegevus
            InputRecipeData(driver, DataOfRecipe1);

            IWebElement saveButton = driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            Thread.Sleep(250);

            IWebElement thisRecipeButton = driver.FindElement(By.XPath($"//button[text()='{DataOfRecipe1[0]}']"));
            thisRecipeButton.Click();

            string recipeNameDetail = driver.FindElement(By.Id("recipeTitle")).Text;
            string recipeDescriptionDetail = driver.FindElement(By.Id("gameDescriptionDetail")).Text;

            Assert.Equal(DataOfRecipe1[0], recipeNameDetail);
            Assert.Equal(DataOfRecipe1[1], recipeDescriptionDetail);
        }

        public void InputRecipeData(IWebDriver driver, string[] dataOfGame1)
        {
            IWebElement inputTitle = driver.FindElement(By.Id("recipeTitle"));
            inputTitle.SendKeys(dataOfGame1[0]);

            IWebElement description = driver.FindElement(By.Id("description"));
            inputTitle.SendKeys(dataOfGame1[1]);

            IWebElement instructions = driver.FindElement(By.Id("instructions"));
            inputTitle.SendKeys(dataOfGame1[2]);

            IWebElement imageUrl = driver.FindElement(By.Id("imageUrl"));
            inputTitle.SendKeys(dataOfGame1[3]);
        }
    }
}