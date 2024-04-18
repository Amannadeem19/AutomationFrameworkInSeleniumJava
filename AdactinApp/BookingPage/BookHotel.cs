using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationFramework.AdactinApp.BookingPage
{
    public class BookPage:BasePage

    {
        #region Locators
        By firstNameTxt = By.Id("first_name");
        By lastNameTxt = By.Id("last_name");
        By billingAddressTxt = By.Id("address");
        By ccNumTxt = By.Id("cc_num");
        By ccTypeDropdown = By.Id("cc_type");
        By ccExpMonthDropdown = By.Id("cc_exp_month");
        By ccExpYearDropdown = By.Id("cc_exp_year");
        By ccCvvTxt = By.Id("cc_cvv");
        By bookNowBtn = By.Id("book_now");
        By cancelBtn = By.Id("cancel");
        #endregion

        public void bookedHotel()
        {
            BasePage.Step = BasePage.Test.CreateNode("BookHotelPage");

            Write(firstNameTxt, "aman");
            Write(lastNameTxt, "nadeem");
            Write(billingAddressTxt, "a7/d block 3a");
            Write(ccNumTxt, "1234567887654321");
            Write(ccTypeDropdown, "VISA");
            Write(ccExpMonthDropdown, "April");
            Write(ccExpYearDropdown, "2024");
            Write(ccCvvTxt, "1234");
            Click(bookNowBtn);
        }
    }
}
