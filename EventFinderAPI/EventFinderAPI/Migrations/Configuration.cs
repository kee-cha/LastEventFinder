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

        protected override void Seed(EventFinderAPI.Models.ApplicationDbContext context)
        {
            context.Events.AddOrUpdate(

            new Models.Events
            {
                EventName = "The 90's Kickback Concert Part 2",
                Date = "02/26/2020",
                Category = "Music",
                SubCategory = "R&B",
                VenueName = "Miller High Life Theatre",
                Street = "500 W Kilbourn Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "Ginuwine",
                Date = "02/13/2020",
                Category = "Music",
                SubCategory = "R&B",
                VenueName = "The Northern Lights Theater",
                Street = "1721 W Canal St",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "The Millennium Tour: Omarion",
                Date = "02/26/2020",
                Category = "Music",
                SubCategory = "R&B",
                VenueName = "UW-Milwaukee Panther Arena",
                Street = "400 W Kilbourn Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "JJ Grey & Mofro",
                Date = "02/08/2020",
                Category = "Music",
                SubCategory = "R&B",
                VenueName = "Turner Hall Ballroom",
                Street = "1040 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "Prince Royce",
                Date = "04/10/2020",
                Category = "Music",
                SubCategory = "R&B",
                VenueName = "The Rave",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "The Lumineers",
                Date = "03/11/2020",
                Category = "Music",
                SubCategory = "Rock",
                VenueName = "FiserV Forum",
                Street = "1111 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "The Lumineers",
                Date = "03/11/2020",
                Category = "Music",
                SubCategory = "Rock",
                VenueName = "FiserV Forum",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "Ozzy Osbourne & Marilyn Manson",
                Date = "07/01/2020",
                Category = "Music",
                SubCategory = "Rock",
                VenueName = "American Family Insurance Amphitheater",
                Street = "639 E Summerfest Pl",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53202"
            },

            new Models.Events
            {
                EventName = "Alter Bridge live in concert",
                Date = "02/15/2020",
                Category = "Music",
                SubCategory = "Rock",
                VenueName = "The Rave",
                Street = "2401 W Wisconsin Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "Elton John",
                Date = "02/15/2020",
                Category = "Music",
                SubCategory = "Rock",
                VenueName = "Fiserv Forum",
                Street = "1111 Vel R. Phillips Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "Florentine @ Estabrook Beer Garden (free)",
                Date = "02/23/2020",
                Category = "Food",
                SubCategory = "Beer Garden",
                VenueName = "Estabrook Beer Garden",
                Street = "4600 Estabrook Pkwy",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },

            new Models.Events
            {
                EventName = "Cooking Class for Young Survivors",
                Date = "01/25/2020",
                Category = "Food",
                SubCategory = "Classes",
                VenueName = "Boelter Event Center",
                Street = "4200 North Port Washington Road",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53212"
            },

            new Models.Events
            {
                EventName = "Cooking Class: Dietary Cooking",
                Date = "03/25/2020",
                Category = "Food",
                SubCategory = "Classes",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },

            new Models.Events
            {
                EventName = "Cooking Class: Cookies + Decorating",
                Date = "02/26/2020",
                Category = "Food",
                SubCategory = "Classes",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },

            new Models.Events
            {
                EventName = "Cooking Class: Roast Chicken",
                Date = "01/29/2020",
                Category = "Food",
                SubCategory = "Classes",
                VenueName = "UWM Student Union, 3rd Floor, Room 348",
                Street = "2200 East Kenwood Boulevard",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },

            new Models.Events
            {
                EventName = "Wine Tasting with the Winemaker: Chasing Harvest",
                Date = "02/4/2020",
                Category = "Food",
                SubCategory = "Wine Tasting",
                VenueName = "Vino Third Ward - Wine Bar & Store",
                Street = "219 East Erie Street",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53211"
            },

            new Models.Events
            {
                EventName = "Big Cheese Quad Rugby Tournament",
                Date = "02/15/2020",
                Category = "Sports",
                SubCategory = "Rugby",
                VenueName = "South Division High School",
                Street = "1515 W Lapham Blvd",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53204",
            },
            new Models.Events
            {
                EventName = "Stoutmen Information Meeting for 2020 Season",
                Date = "01/28/2020",
                Category = "Sports",
                SubCategory = "Rugby",
                VenueName = "Annie's Fountain City Cafe",
                Street = "72 S Main St",
                City = "Fond du Lac",
                State = "WI",
                ZipCode = "54935"
            },

            new Models.Events
            {
                EventName = "2020 Lakefront 7s Rugby Festival",
                Date = "06/27/2020",
                Category = "Sports",
                SubCategory = "Rugby",
                VenueName = "Annie's Fountain City Cafe",
                Street = "1010 N Lincoln Memorial Dr",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53202"
            },

            new Models.Events
            {
                EventName = "Milwaukee Wave vs. Rochester Lancers",
                Date = "01/25/2020",
                Category = "Sports",
                SubCategory = "Football",
                VenueName = "Annie's Fountain City Cafe",
                Street = "400 W Kilbourn Ave",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "Georgetown Hoyas at Marquette Golden Eagles Womens Basketball",
                Date = " 01/24/2020",
                Category = "Sports",
                SubCategory = "Basketball",
                VenueName = "Al McGuire Center",
                Street = "770 N 12th St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "DePaul Blue Demons at Marquette Golden Eagles Basketball",
                Date = "  02/01/2020",
                Category = "Sports",
                SubCategory = "Basketball",
                VenueName = "Fiserv Forum",
                Street = "1111 Vel R. Phillips Ave",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53203"

            },

            new Models.Events
            {
                EventName = "Wright State Raiders Mens Basketball",
                Date = "  02/01/2020",
                Category = "Sports",
                SubCategory = "Basketball",
                VenueName = "University of Wisconsin-Milwaukee",
                Street = "400 W Kilbourn Ave",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53203"
            },

            new Models.Events
            {
                EventName = "FUJI BJJ Milwaukee Open",
                Date = "  02/22/2020",
                Category = "Sports",
                SubCategory = "MMA",
                VenueName = "Milwaukee Lutheran High School",
                Street = "9700 W Grantosa Dr",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53222"
            },

            new Models.Events
            {
                EventName = "Jiu Jitsu & Yoga for Holistic Healing: January Edition",
                Date = "  01/22/2020",
                Category = "Sports",
                SubCategory = "MMA",
                VenueName = "FitPOWER LLC",
                Street = "5425 W Vliet St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53208"
            },

            new Models.Events
            {
                EventName = "Kickboxing for MADACC",
                Date = "  01/26/2020",
                Category = "Sports",
                SubCategory = "MMA",
                VenueName = "Safe and Strong Fitness",
                Street = "2612 S Greeley St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53207"
            },

            new Models.Events
            {
                EventName = "Member Tour: Modern Art",
                Date = "  01/18/2020",
                Category = "Art",
                SubCategory = "Exhibitions",
                VenueName = "Milwaukee Art Museum",
                Street = "700 N Art Museum Dr",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53202"
            },

            new Models.Events
            {
                EventName = "Exploring the Core Curriculum: Individuals and Communities",
                Date = "  01/23/2020",
                Category = "Art",
                SubCategory = "Exhibitions",
                VenueName = "Haggerty Museum of Art",
                Street = "1234 W Tory Hill St",
                City = "Milwaukee",
                State = "WI",
                ZipCode = "53233"
            },

            new Models.Events
            {
                EventName = "2020 Wisconsin Artists Biennial",
                Date = "  01/25/2020",
                Category = "Art",
                SubCategory = "Exhibitions",
                VenueName = "Museum of Wisconsin Art",
                Street = "205 Veterans Ave",
                City = "WestBend",
                State = "WI",
                ZipCode = "53095"
            },

            new Models.Events
            {
                EventName = "RAM 11th Annual International PEEPS Art Competition",
                Date = "  01/25/2020",
                Category = "Art",
                SubCategory = "Competition",
                VenueName = "Racine Art Museum",
                Street = "441 Main St",
                City = "Racine",
                State = "WI",
                ZipCode = "53403"
            },

            new Models.Events
            {
                EventName = "Creative Arts Competition",
                Date = "02/05/2020",
                Category = "Art",
                SubCategory = "Competition",
                VenueName = "Milwaukee VA Medical Center",
                Street = "5000 W National Ave",
                City = "Milwuakee",
                State = "WI",
                ZipCode = "53295"
            },

            new Models.Events
            {
                EventName = "Indoor Mural Competition",
                Date = "  01/24/2020",
                Category = "Art",
                SubCategory = "Competition",
                VenueName = "The Branch ",
                Street = "1501 Washington Ave",
                City = "Racine",
                State = "WI",
                ZipCode = "53403"
            }
            );

        }
    }
}

