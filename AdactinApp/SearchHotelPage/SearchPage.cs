using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationFramework.AdactinApp.SearchHotelPage
{
    public class SearchPage:BasePage
    {
        #region Locators
        By locationDropdown = By.Id("location");
        By hotelDropdown = By.Id("hotels");
        By roomTypeDropdown = By.Id("room_type");
        By roomsDropdown = By.Id("room_nos");
        By checkInDate = By.Id("datepick_in");
        By checkOutDate = By.Id("datepick_out");
        By noAdultsDropdown = By.Id("adult_room");
        By noChildsDropdown = By.Id("child_room");
        By searchBtn = By.Id("Submit");
        By resetBtn = By.Id("Reset");
        #endregion

        public void searchHotel()
        {
            BasePage.Step = BasePage.Test.CreateNode("SearchPage");

            Write(locationDropdown, "Sydney");
            Write(hotelDropdown, "Hotel Creek");
            Write(roomTypeDropdown, "Standard");
            Write(roomsDropdown, "3 - Three");
            Write(checkInDate, "23/03/2024");
            Write(checkOutDate, "25/03/2024");
            Write(noAdultsDropdown, "1 - One");
            Write(noChildsDropdown, "1 - One");
            Click(searchBtn);


        }

    }
}
