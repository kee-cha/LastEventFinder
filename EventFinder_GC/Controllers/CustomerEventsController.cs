using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventFinder_GC.Models;

namespace EventFinder_GC.Controllers
{
    public class CustomerEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerEvents
        public ActionResult Index()
        {
            var customerEvents = db.CustomerEvents.Include(c => c.Customer).Include(c => c.Event);
            
            return View("List",customerEvents.ToList());
        }

        // GET: CustomerEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEvent customerEvent = db.CustomerEvents.Find(id);
            if (customerEvent == null)
            {
                return HttpNotFound();
            }
            return View(customerEvent);
        }

        // GET: CustomerEvents/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName");
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName");
            return View();
        }

        // POST: CustomerEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,CustomerId")] CustomerEvent customerEvent)
        {
            if (ModelState.IsValid)
            {
                db.CustomerEvents.Add(customerEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerEvent.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", customerEvent.EventId);
            return View(customerEvent);
        }

        public ActionResult FilterByCat(string subCategory)
        {
            var events = db.Events.Include(e => e.Address).Include(e => e.Host);
            var newEvents = events.Where(e => e.SubCategory == subCategory);
            return View("Index", newEvents);
        }

        // GET: CustomerEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEvent customerEvent = db.CustomerEvents.Find(id);
            if (customerEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerEvent.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", customerEvent.EventId);
            return View(customerEvent);
        }

        // POST: CustomerEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,CustomerId")] CustomerEvent customerEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FirstName", customerEvent.CustomerId);
            ViewBag.EventId = new SelectList(db.Events, "EventId", "EventName", customerEvent.EventId);
            return View(customerEvent);
        }

        // GET: CustomerEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerEvent customerEvent = db.CustomerEvents.Find(id);
            if (customerEvent == null)
            {
                return HttpNotFound();
            }
            return View(customerEvent);
        }

        // POST: CustomerEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerEvent customerEvent = db.CustomerEvents.Find(id);
            db.CustomerEvents.Remove(customerEvent);
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
