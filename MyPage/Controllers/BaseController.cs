﻿using Microsoft.Ajax.Utilities;
using MyPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MyPage.Controllers
{

    //hello world
    public class BaseController : Controller
    {

        public TYO_BookersEntities db = new TYO_BookersEntities();
               
        //testtttttttttttt
        public Dictionary<int,int> getHotelRoomCounts()
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
        public List<Countries> getAllCountries() 
        {
            var allCountries = db.Countries.ToList();

            return allCountries;
        }
    }
}