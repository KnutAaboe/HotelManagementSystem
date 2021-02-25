using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp;

namespace WebApp.Controllers
{
    public class bookingsController : Controller
    {
        private Hotel_ManagerEntities db = new Hotel_ManagerEntities();

        // GET: bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.guest).Include(b => b.room);
            return View(bookings.ToList());
        }

        // GET: bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: bookings/Create
        public ActionResult Create()
        {
            ViewBag.phoneNr = new SelectList(db.Guests, "phoneNr", "firstname");
            ViewBag.roomNr = new SelectList(db.Rooms, "roomNr", "roomType");
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,phoneNr,roomNr,startTime,endTime")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.phoneNr = new SelectList(db.Guests, "phoneNr", "firstname", booking.phoneNr);
            ViewBag.roomNr = new SelectList(db.Rooms, "roomNr", "roomType", booking.roomNr);
            return View(booking);
        }

        // GET: bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.phoneNr = new SelectList(db.Guests, "phoneNr", "firstname", booking.phoneNr);
            ViewBag.roomNr = new SelectList(db.Rooms, "roomNr", "roomType", booking.roomNr);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,phoneNr,roomNr,startTime,endTime")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.phoneNr = new SelectList(db.Guests, "phoneNr", "firstname", booking.phoneNr);
            ViewBag.roomNr = new SelectList(db.Rooms, "roomNr", "roomType", booking.roomNr);
            return View(booking);
        }

        // GET: bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
