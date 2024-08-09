using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MyPage.Models;

namespace MyPage.Controllers
{
    public class HotelsController : BaseController

    {

        // GET: Hotels
        [Authorize]
        public ActionResult Index()
        {

            ViewBag.HotelRoomCountList = getHotelRoomCounts();
                

            return View(db.Hotels.ToList());
        }
       
        


        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.CompanyNameList = GetCompanyList();
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKID,HotelName,Active,Email,WebAddress,Phone,HotelGeneralManagerName,HotelGeneralManagerEmail,HotelGeneralManagerPhone,HotelContactPerson1Title,HotelContactPerson1Name,HotelContactPerson1Phone,HotelContactPerson1Email,Address1,City,Country,ZipCode,HotelBonus,RecorderDate,RecorderUser,ModifierDate,ModifierUser,SortOrder")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotels);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKID,HotelName,Active,FKHotelGroupCode,Email,WebAddress,Phone,MobilePhone,HotelGeneralManagerName,HotelGeneralManagerEmail,HotelGeneralManagerPhone,HotelContactPerson1Title,HotelContactPerson1Name,HotelContactPerson1Phone,HotelContactPerson1Email,HotelContactPerson2Title,HotelContactPerson2Name,HotelContactPerson2Phone,HotelContactPerson2Email,Address1,Address2,City,State,Country,ZipCode,HotelBonus,RecorderDate,RecorderUser,ModifierDate,ModifierUser,HotelPic,SortOrder")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotels);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotels hotels = db.Hotels.Find(id);
            if (hotels == null)
            {
                return HttpNotFound();
            }
            return View(hotels);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotels hotels = db.Hotels.Find(id);
            db.Hotels.Remove(hotels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
