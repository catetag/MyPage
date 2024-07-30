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
    public class ReservationRoomsController : BaseController
    {
        // GET: ReservationRooms
        public ActionResult Index()
        {
            using (var dbContext = new TYO_BookersEntities())
            {
                // çok veri geldiğinden site yavaşlıyor geçici
                var data = dbContext.ReservationRooms.Take(100).ToList();

                return View(data);
            }
        }

        // GET: ReservationRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationRooms reservationRooms = db.ReservationRooms.Find(id);
            if (reservationRooms == null)
            {
                return HttpNotFound();
            }
            return View(reservationRooms);
        }

        // GET: ReservationRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservationRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKID,FKReservationID,FKHotelID,FKHotelRoomID,AdultCount,ChildCount,InfantCount,BonusPoints,RecorderDate,RecorderUser,ModifierDate,ModifierUser,RoomStatus,CheckinDate,CheckoutDate,PromotionPoints,RoomCount,ServiceResult,StatusUpdateDate,MatchByName,MaxAdult,MaxChild,MaxInfant")] ReservationRooms reservationRooms)
        {
            if (ModelState.IsValid)
            {
                db.ReservationRooms.Add(reservationRooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservationRooms);
        }

        // GET: ReservationRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationRooms reservationRooms = db.ReservationRooms.Find(id);
            if (reservationRooms == null)
            {
                return HttpNotFound();
            }
            return View(reservationRooms);
        }

        // POST: ReservationRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKID,FKReservationID,FKHotelID,FKHotelRoomID,AdultCount,ChildCount,InfantCount,BonusPoints,RecorderDate,RecorderUser,ModifierDate,ModifierUser,RoomStatus,CheckinDate,CheckoutDate,PromotionPoints,RoomCount,ServiceResult,StatusUpdateDate,MatchByName,MaxAdult,MaxChild,MaxInfant")] ReservationRooms reservationRooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationRooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationRooms);
        }

        // GET: ReservationRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationRooms reservationRooms = db.ReservationRooms.Find(id);
            if (reservationRooms == null)
            {
                return HttpNotFound();
            }
            return View(reservationRooms);
        }

        // POST: ReservationRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationRooms reservationRooms = db.ReservationRooms.Find(id);
            db.ReservationRooms.Remove(reservationRooms);
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
