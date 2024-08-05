using Microsoft.Ajax.Utilities;
using MyPage.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public List<string> countryList()
        {

            var liste = db.Companies.Select(p => p.City).ToList();
            ViewBag.liste = liste;

            return liste;
        }

        public Dictionary<int, string> GetCompanyList()
        {                   

                Dictionary<int, string> retValue = db.Companies.ToDictionary(x => x.PKID, x => x.CompanyName);
                return retValue;

        }

        public Dictionary<int, string> GetCompanyListToBookers()
        {            
            //Dictionary<int, string> returnValue = new Dictionary<int, string>();

            //var test1 = int.Parse(db.Bookers.Select(x => x.FKCompanyID).FirstOrDefault());
            //var test2 = db.Companies.Where(x => test1 == x.PKID).Select(x => x.CompanyName).SingleOrDefault();

            //returnValue.Add(test1, test2);

            Dictionary<int, string> retValue = db.Companies.ToDictionary(x => x.PKID, x => x.CompanyName);
            return retValue;


                
        }

    }
    }
