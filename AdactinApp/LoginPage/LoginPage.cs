using OpenQA.Selenium;


namespace AutomationFramework
{
    public class LoginPage:BasePage
    {
        By usernameTXT = By.Id("username");
        By passwordTXT = By.Id("password");
        By loginBTN = By.Id("login");

        public void Login(string url, string username, string pass, string locator, string expectedMessage)
        {

            BasePage.Step = BasePage.Test.CreateNode("LoginPage");

            OpenUrl(url);
            
            Write(usernameTXT, username);
            
            Write(passwordTXT, pass);
       
            Click(loginBTN);

            By by = By.ClassName(locator);
            
            string actualText = GetText(by);
            
            Assertion(expectedMessage, actualText);

        }
    }
}
