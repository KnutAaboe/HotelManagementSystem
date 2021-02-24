using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp;
using WebApp.Rooms;

namespace WebApp.Controllers
{
    public class RecieptsController : Controller
    {
        private Hotel_ManagerEntities db = new Hotel_ManagerEntities();

        // GET: Reciepts
        public ActionResult Index()
        {
            int id;
            if (Request.Cookies["Auth"] != null && Request.Cookies["GuestId"] != null)
            {
                id = int.Parse(Request.Cookies["GuestId"].Value);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            // Riktig id i x.ID?
            var rec = db.Bookings.ToList().Where(x => x.ID == id);
            return View(rec.ToList());
        }

        // GET: Reciepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.Bookings.Find(id);

            //RoomId riktig?
            room rooms = db.Rooms.Find(booking.RoomId);
            ViewBag.Room = rooms;
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Reciepts/Create
        public ActionResult Create()
        {
            List<SelectListItem> RoomType = new List<SelectListItem>();

            List<SelectListItem> RoomQuality = new List<SelectListItem>();

            if (db.Rooms.ToList().Any(x => x.roomType == "Single Room" && x.roomState.GetType() == typeof(AvailableState)))
            {
                RoomType.Add(new SelectListItem { Text = "Single Room", Value = "Single Room" });

            }
            if (db.Rooms.ToList().Any(x => x.roomType == "Double Room" && x.roomState.GetType() == typeof(AvailableState))) 
            {
                RoomType.Add(new SelectListItem { Text = "Double Room", Value = "Double Room" });

            }
            if (db.Rooms.ToList().Any(x => x.roomQuality == "Standard" && x.roomState.GetType() == typeof(AvailableState))) 
            {
                RoomQuality.Add(new SelectListItem { Text = "Standard", Value = "Standard" });

            }
            if (db.Rooms.ToList().Any(x => x.roomType == "Vip" && x.roomState.GetType() == typeof(AvailableState))) 
            {
                RoomQuality.Add(new SelectListItem { Text = "Vip", Value = "Vip" });
            }


            ViewBag.RoomTypes = RoomType;
            ViewBag.RoomQualities = RoomQuality;


            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName");
            return View();
        }

        // POST: Reciepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StayedFromDate,StayedToDate,RoomTypes,RoomQualities")] booking booking)
        {
            if (ModelState.IsValid)
            {
                string RoomQuality = Request.Form["RoomQualities"];
                string RoomType = Request.Form["RoomTypes"];

                if (Request.Cookies["Auth"] != null && Request.Cookies["GuestId"] != null)
                {
                    booking.guest.id = int.Parse(Request.Cookies["GuestId"].Value);
                    booking.room.roomQuality = RoomQuality;
                    booking.room.roomType = RoomType;

                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
                booking.GuestName = db.Guests.Find(booking.guest.id).lastname;

                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("BadRecieptView");
        }

        // GET: Reciepts/Edit/5
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
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName", booking.guest.id);
            return View(booking);
        }

        // POST: Reciepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StayedFromDate,StayedToDate,SettledDate,StateString,GuestId")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName", booking.guest.id);
            return View(booking);
        }

        // GET: Reciepts/Delete/5
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

        // POST: Reciepts/Delete/5
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
