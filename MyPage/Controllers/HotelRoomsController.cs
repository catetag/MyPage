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
    public class HotelRoomsController : BaseController
    {


        public ActionResult roomsinhotels(int id)
        {
            var hotelRooms = db.HotelRooms.Where(x => x.FKHotelID == id).ToList();

            return View(hotelRooms); //bu bir testtttttttttttttttttttttt5555555555555
        }
        public ActionResult Index()
        {
            
            return View(db.HotelRooms.ToList());

        }
        // GET: HotelRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            if (hotelRooms == null)
            {
                return HttpNotFound();
            }
            return View(hotelRooms);
        }

        // GET: HotelRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKID,FKHotelID,RoomName,Description,Images,OperatorRoomCode,PMSRoomCode,RoomBonus,RecorderDate,RecorderUser,ModifierDate,ModifierUser,SortOrder,BookeraVerilebilir,MaxAdult,MaxChild,MaxInfant")] HotelRooms hotelRooms)
        {
            if (ModelState.IsValid)
            {
                db.HotelRooms.Add(hotelRooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelRooms);
        }

        // GET: HotelRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            if (hotelRooms == null)
            {
                return HttpNotFound();
            }
            return View(hotelRooms);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKID,FKHotelID,RoomName,Description,Images,OperatorRoomCode,PMSRoomCode,RoomBonus,RecorderDate,RecorderUser,ModifierDate,ModifierUser,SortOrder,BookeraVerilebilir,MaxAdult,MaxChild,MaxInfant")] HotelRooms hotelRooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelRooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelRooms);
        }

        // GET: HotelRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            if (hotelRooms == null)
            {
                return HttpNotFound();
            }
            return View(hotelRooms);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            db.HotelRooms.Remove(hotelRooms);
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
