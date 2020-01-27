using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EventFinder_GC.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace EventFinder_GC.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            List<Event> currentEvents = new List<Event>();
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            var events = db.CustomerEvents.Where(c=>c.CustomerId == customer.CustomerId).ToList();
            var allEvents = db.Events.ToList();
            foreach (var item in allEvents)
            {
                foreach (var ids in events)
                {
                    if (ids.EventId == item.EventId)
                    {
                        currentEvents.Add(item);
                    }
                }
            }
            return View(currentEvents);
        }
        public ActionResult FilterByCat(string subCategory)
        {
            var events = db.Events.Include(e => e.Host);                   
            var newEvents = events.Where(e => e.SubCategory == subCategory);            
            return View("Index", newEvents);
        }
        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        public async Task<ActionResult> Join(Event joinEvent, int id)
        {
            joinEvent = new Event();
            string userId = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44355/api/Events/"+id;
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                EventApi events = JsonConvert.DeserializeObject<EventApi>(jsonResult);

                joinEvent.EventName = events.EventName;
                joinEvent.VenueName = events.VenueName;
                joinEvent.Street = events.Street;
                joinEvent.Date = events.Date;
                joinEvent.Category = events.Category;
                joinEvent.SubCategory = events.SubCategory;
                joinEvent.City = events.City;
                joinEvent.State = events.State;
                joinEvent.ZipCode = events.ZipCode;
                joinEvent.HostId = events.HostId;
                db.Events.Add(joinEvent);
                db.SaveChanges();
                CustomerEvent custEvent = new CustomerEvent();
                custEvent.EventId = joinEvent.EventId;
                custEvent.CustomerId = customer.CustomerId;
                db.CustomerEvents.Add(custEvent);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Events/Create
        public ActionResult Create()
        {
            Event @event = new Event();
            return View(@event);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.HostId = new SelectList(db.Hosts, "HostId", "FirstName", @event.HostId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.HostId = new SelectList(db.Hosts, "HostId", "FirstName", @event.HostId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostId = new SelectList(db.Hosts, "HostId", "FirstName", @event.HostId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
