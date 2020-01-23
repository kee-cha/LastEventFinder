﻿using System;
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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public async Task<ActionResult> Index(bool? seeAllEvents)
        {
            var id = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.ApplicationId == id).SingleOrDefault();
            HttpClient client = new HttpClient();
            string url = "https://localhost:44355/api/Events";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                //deserialize response 
                EventApi[] events = JsonConvert.DeserializeObject<EventApi[]>(jsonResult);
                if (seeAllEvents != true)
                {
                    events = FilterByInterest(events, customer).ToArray();
                }

                //pass deserialized response as object to view, then change model in view from customer
                return View(events);
            }
            else
            {
                //this should realistically never happen
                return View();
            }
        }

        public List<EventApi> FilterByInterest(EventApi[] events, Customer customer)
        {
            List<EventApi> filteredEvents = new List<EventApi>();
            foreach (var item in events)
            {
                if (customer.ArtInterest == true && item.Category == "Art" || customer.FoodInterest == true && item.Category == "Food" || customer.MusicInterest == true && item.Category == "Music" || customer.SportInterest == true && item.Category == "Sport" || customer.TechInterest == true && item.Category == "Tech")
                {
                    filteredEvents.Add(item);
                }
            }
            return filteredEvents;
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;

                //must cast to int as session represents object prior to typecasting
                customer.AddressId = (int)Session["AddressId"];

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street", customer.AddressId);
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street", customer.AddressId);
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,AddressId,ApplicationId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "AddressId", "Street", customer.AddressId);
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
