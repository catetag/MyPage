using Microsoft.Ajax.Utilities;
using MyPage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;




namespace MyPage.Controllers
{

    
    public class BaseController : Controller
    {

        public TYO_BookersEntities db = new TYO_BookersEntities();


        public Dictionary<int, int> getHotelRoomCounts()
        {
            Dictionary<int, int> returnValue = new Dictionary<int, int>();

            foreach (var hotel in db.Hotels)
            {
                var hotelRoomList = db.HotelRooms.Where(x => x.FKHotelID == hotel.PKID).ToList();
                int hotelRoomCount = hotelRoomList.Count();
                returnValue.Add(hotel.PKID, hotelRoomCount);
            }


            return returnValue;
        }

       


    }
}