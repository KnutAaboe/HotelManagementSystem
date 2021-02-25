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
    public class guestsController : Controller
    {
        private Hotel_ManagerEntities db = new Hotel_ManagerEntities();

        // GET: guests
        public ActionResult Index()
        {
            return View(db.Guests.ToList());
        }

        // GET: guests/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // GET: guests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "firstname,lastname,phoneNr,dob,username,pass")] guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guest);
        }

        // GET: guests/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "firstname,lastname,phoneNr,dob,username,pass")] guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: guests/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
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
