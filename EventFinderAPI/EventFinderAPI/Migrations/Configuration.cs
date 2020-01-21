namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventFinderAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventFinderAPI.Models.ApplicationDbContext db)
        {
            //  This method will be called after migrating to the latest version.
            db.Events.AddOrUpdate(
            new Models.Events
            {
                EventName = "The 90's Kickback Concert Part 2",
                Date = "Feb,26,2020",
                Category = "Music",
                SubCategory = "r&b",
                VenueName = "Miller High Life Theatre",
                Street = "500 W Kilbourn Ave, Milwaukee, WI",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },
                new Models.Events
                {
                    EventName = "Ginuwine",
                    Date = "Feb,13,2020",
                    Category = "Music",
                    SubCategory = "r&b",
                    VenueName = "The Northern Lights Theater",
                    Street = "1721 W Canal St, Milwaukee, WI",
                    City = "Milwuakee",
                    State = "WI",
                    ZipCode = "53233"
                },
            new Models.Events
            {
                EventName = "The Millennium Tour: Omarion",
                Date = "Feb,26,2020",
                Category = "Music",
                SubCategory = "r&b",
                VenueName = "UW-Milwaukee Panther Arena",
                Street = "400 W Kilbourn Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "JJ Grey & Mofro",
                Date = "Feb,8,2020",
                Category = "Music",
                SubCategory = "r&b",
                VenueName = "Turner Hall Ballroom",
                Street = "1040 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },
            new Models.Events
            {
                EventName = "Prince Royce",
                Date = "April,10,2020",
                Category = "Music",
                SubCategory = "r&b",
                VenueName = "The Rave",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "The Lumineers",
                Date = "March,11,2020",
                Category = "Music",
                SubCategory = "rock",
                VenueName = "FiserV Forum",
                Street = "1111 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },
            new Models.Events
            {
                EventName = "The Lumineers",
                Date = "March,11,2020",
                Category = "Music",
                SubCategory = "rock",
                VenueName = "FiserV Forum",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },
            new Models.Events
            {
                EventName = "Ozzy Osbourne & Marilyn Manson",
                Date = "July,1,2020",
                Category = "Music",
                SubCategory = "rock",
                VenueName = "American Family Insurance Amphitheater",
                Street = "639 E Summerfest Pl",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53202"
            },
            new Models.Events
            {
                EventName = "Alter Bridge live in concert",
                Date = "Febuary,15,2020",
                Category = "Music",
                SubCategory = "rock",
                VenueName = "The Rave",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },
            new Models.Events
            {
                EventName = "Elton John",
                Date = "Febuary,15,2020",
                Category = "Music",
                SubCategory = "rock",
                VenueName = "Fiserv Forum",
                Street = "1111 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },
            new Models.Events
            {
                EventName = "Florentine @ Estabrook Beer Garden (free)",
                Date = "Febuary,23,2020",
                Category = "Food",
                SubCategory = "beer garden",
                VenueName = "Estabrook Beer Garden",
                Street = "4600 Estabrook Pkwy,",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },
            new Models.Events
            {
                EventName = "Cooking Class for Young Survivors",
                Date = "January,25,2020",
                Category = "Food",
                SubCategory = "class",
                VenueName = "Boelter Event Center",
                Street = "4200 North Port Washington Road",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53212"
            },
            new Models.Events
            {
                EventName = "Cooking Class: Dietary Cooking",
                Date = "March,25,2020",
                Category = "Food",
                SubCategory = "class",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },
            new Models.Events
            {
                EventName = "Cooking Class: Cookies + Decorating",
                Date = "Febuary,26,2020",
                Category = "Food",
                SubCategory = "class",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },
            new Models.Events
            {
                EventName = "Cooking Class: Roast Chicken",
                Date = "January,29,2020",
                Category = "Food",
                SubCategory = "class",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },
            new Models.Events
            {
                EventName = "Wine Tasting with the Winemaker: Chasing Harvest",
                Date = "February,04,2020",
                Category = "Food",
                SubCategory = "wine tasting",
                VenueName = "Vino Third Ward - Wine Bar & Store",
                Street = "219 East Erie Street",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
