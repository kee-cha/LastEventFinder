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
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace EventFinder_GC.Controllers
{
    public class CustomersController : TwilioController
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

        public async Task<ActionResult> FilterByCatAsync(string subCategory)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44355/api/Events";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                //deserialize response 
                EventApi[] events = JsonConvert.DeserializeObject<EventApi[]>(jsonResult);
                //pass deserialized response as object to view, then change model in view from customer
                var newEvents = events.Where(e => e.SubCategory == subCategory);
                return View("Index", newEvents);
            }
            else
            {
                //this should realistically never happen
                return View();
            }
            
        }
        public async Task<ActionResult> FilterZipAsync(string zipCode)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44355/api/Events";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                //deserialize response 
                EventApi[] events = JsonConvert.DeserializeObject<EventApi[]>(jsonResult);
                //pass deserialized response as object to view, then change model in view from customer
                var newEvents = events.Where(e => e.ZipCode == zipCode);
                return View("Index", newEvents);
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


        public ActionResult RedirectSMSRate()
        {
            const string accountSid = "ACcecf5051a0d580c335c6a25bbb9c470e";
            const string authToken = "4962acf649231d182bf63026d0e4757d";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            body: "Thank you for your participation in our feature! Please reply with a rating for your event with an integer between 1 and 5.",
            from: new Twilio.Types.PhoneNumber("+12512654255"),
            to: new Twilio.Types.PhoneNumber("+19206557490")
            );

            Console.WriteLine(message.Sid);
            return RedirectToAction("Index", "Home");
        }


        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Host eventHost = new Host();        
            EventApi singleEvent = new EventApi();
            double? rating = 0;
            double count = 0;
            Session["EventId"] = id;

            HttpClient client = new HttpClient();
            string url = "https://localhost:44355/api/Events";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                EventApi[] events = JsonConvert.DeserializeObject<EventApi[]>(jsonResult);
                foreach (var item in events)
                {
                    if (item.EventId == id)
                    {
                        singleEvent = item;
                        eventHost = db.Hosts.Where(h => h.HostId == singleEvent.HostId).FirstOrDefault();
                        await GetCoord(singleEvent);
                    }
                }

                foreach (var item in events)
                {
                    //pull all categories from events list where category = event category of singleEvent and has host id of eventHost
                    if((item.Category == singleEvent.Category) && (item.HostId == singleEvent.HostId))
                    {
                        count++;
                        rating += item.Rating;
                    }
                }

                double? avgRating = rating / count; //get average rating
                //viewbag the event host full name 
                ViewBag.EventHostName = eventHost.FirstName + " " + eventHost.LastName;
                ViewBag.HostRatingByCategory = avgRating;
            }
            return View(singleEvent);
        }
        public async Task<ActionResult> GetCoord(EventApi singleEvent)
        {
            string location = singleEvent.Street + "+" + singleEvent.City + "+" + singleEvent.State + "+" + singleEvent.ZipCode;
            HttpClient client = new HttpClient();
            string key = Key.myKey;
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + location + "&key=" + key;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoModel GeoResult  = JsonConvert.DeserializeObject<GeoModel>(result);

                singleEvent.Latitude = GeoResult.results[0].geometry.location.lat;
                singleEvent.Longitude = GeoResult.results[0].geometry.location.lng;
                ViewBag.Key = "https://maps.googleapis.com/maps/api/js?key=" + key + "&callback=initMap";
                await GetDirection();
                return View(singleEvent);
            }

            return View(singleEvent);           
   
        }
        
        public async Task<ActionResult> GetDirection()
        {
            string userId = User.Identity.GetUserId();
            Customer customer = new Customer();
            customer = db.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            string location = customer.Street + "+" + customer.City + "+" + customer.State + "+" + customer.ZipCode;
            HttpClient client = new HttpClient();
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + location + "&key=" + Key.myKey;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoModel GeoResult = JsonConvert.DeserializeObject<GeoModel>(result);
                ViewBag.CustLat = GeoResult.results[0].geometry.location.lat;
                ViewBag.CustLng = GeoResult.results[0].geometry.location.lng;
                return View();
            }
            return View();
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
                //customer.AddressId = (int)Session["AddressId"];

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("LogOut", "Account");
            }

            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
            return View(customer);
        }
        
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", customer.ApplicationId);
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
