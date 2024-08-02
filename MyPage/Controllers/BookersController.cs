using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPage.Models;

namespace MyPage.Controllers
{
    public class BookersController : BaseController
    {

        public ActionResult hotelnames()
        {
           
            return View();
        }

        // GET: Bookers
        public ActionResult Index()
        {
            ViewBag.GetCompanyListToBookers = GetCompanyListToBookers();
            var categories = db.Bookers.Take(20).ToList();
            ViewBag.Categories = new SelectList(categories, "Country");


            return View(db.Bookers.ToList());
        }

        // GET: Bookers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookers bookers = db.Bookers.Find(id);
            if (bookers == null)
            {
                return HttpNotFound();
            }
            return View(bookers);
        }

        // GET: Bookers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyNameList = GetCompanyList();
            
            return View();
        }

        // POST: Bookers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKID,FKCompanyID,HotelGroupCode,Active,Email,Pass,FirstName,LastName,Phone,MobilePhone,Address1,Address2,City,State,Country,RecorderDate,RecorderUser,ModifierDate,ModifierUser,Role,AgencyName,AgencyEmail,AgencyWebAddress,AgencyAddress,AgencyPhone,AgencyLicence,AgencyOwner,AgencyZipCode,AgencyCity,AgencyCountry,Gender,ConfirmKVVK")] Bookers bookers)
        {
            if (ModelState.IsValid)
            {
                db.Bookers.Add(bookers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookers);
        }

        // GET: Bookers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookers bookers = db.Bookers.Find(id);
            if (bookers == null)
            {
                return HttpNotFound();
            }
            return View(bookers);
        }

        // POST: Bookers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKID,FKCompanyID,HotelGroupCode,Active,Email,Pass,FirstName,LastName,Phone,MobilePhone,Address1,Address2,City,State,Country,RecorderDate,RecorderUser,ModifierDate,ModifierUser,Role,AgencyName,AgencyEmail,AgencyWebAddress,AgencyAddress,AgencyPhone,AgencyLicence,AgencyOwner,AgencyZipCode,AgencyCity,AgencyCountry,Gender,ConfirmKVVK")] Bookers bookers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookers);
        }

        // GET: Bookers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookers bookers = db.Bookers.Find(id);
            if (bookers == null)
            {
                return HttpNotFound();
            }
            return View(bookers);
        }

        // POST: Bookers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookers bookers = db.Bookers.Find(id);
            db.Bookers.Remove(bookers);
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
