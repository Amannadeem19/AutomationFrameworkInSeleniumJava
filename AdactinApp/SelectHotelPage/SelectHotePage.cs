using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationFramework.AdactinApp.SelectHotelPage
{
    public class SelectHotePage: BasePage
    {
        #region Locators
        By selectRadioBtn = By.Id("radiobutton_0");
        By continueBtn = By.Id("continue");
        By cancelBtn= By.Id("cancel");
        #endregion

        public void selectHotel()
        {
            BasePage.Step = BasePage.Test.CreateNode("SelectHotelPage");

            Click(selectRadioBtn);
            Click(continueBtn);
        }
    }
}
