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
                EventName = "Big Cheese Quad Rugby Tournament",
                Date = "Febuary,15,2020",
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
                        Date = "Januray,28,2020",
                        Category = "Sports",
                        SubCategory = "Rugby",
                        VenueName = "Annie's Fountain City Cafe",
                        Street = "72 S Main St, Fond du Lac",
                        City = "Milwaukee",
                        State = "WI",
                        ZipCode = "54935"
                    },
                    new Models.Events
                    {
                        EventName = "2020 Lakefront 7s Rugby Festival",
                        Date = "June,27,2020",
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
                        Date = "January,25,2020",
                        Category = "Sports",
                        SubCategory = "FootBall",
                        VenueName = "Annie's Fountain City Cafe",
                        Street = "400 W Kilbourn Ave",
                        City = "Milwaukee",
                        State = "WI",
                        ZipCode = "53203"
                    },
                    new Models.Events
                    {
                        EventName = "Georgetown Hoyas at Marquette Golden Eagles Womens Basketball",
                        Date = " January,24,2020",
                        Category = "Sports",
                        SubCategory = "BasketBall",
                        VenueName = "Al McGuire Center",
                        Street = "770 N 12th St",
                        City = "Milwaukee",
                        State = "WI",
                        ZipCode = "53233"
                    },
                    new Models.Events
                    {
                        EventName = "DePaul Blue Demons at Marquette Golden Eagles Basketball",
                        Date = "  Febuary,1,2020",
                        Category = "Sports",
                        SubCategory = "BasketBall",
                        VenueName = "Fiserv Forum",
                        Street = "1111 Vel R. Phillips Ave",
                        City = "Milwaukee",
                        State = "WI",
                        ZipCode = "53203"
                    },
                    new Models.Events
                    {
                        EventName = "Wright State Raiders Mens Basketball",
                        Date = "  Febuary,1,2020",
                        Category = "Sports",
                        SubCategory = "BasketBall",
                        VenueName = "University of Wisconsin-Milwaukee",
                        Street = "400 W Kilbourn Ave",
                        City = "Milwaukee",
                        State = "WI",
                        ZipCode = "53203"
                    },
                    new Models.Events

                    {
                        EventName = "FUJI BJJ Milwaukee Open",
                        Date = "  Febuary,22,2020",
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
                        Date = "  January,22,2020",
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
                        Date = "  January,26,2020",
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
                        Date = "  January,18,2020",
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
                        Date = "  January,23,2020",
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
                        Date = "  January,25,2020",
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
                        Date = "  January,25,2020",
                        Category = "Art",
                        SubCategory = "Competition",
                        VenueName = "Racine Art Museum",
                        Street = "441 Main St",
                        City = "Racine",
                        State = "WI",
                        ZipCode = "530403"
                    },
                    new Models.Events
                    {
                        EventName = "Creative Arts Competition",
                        Date = "  Febuary,5,2020",
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
                        Date = "  January,24,2020",
                        Category = "Art",
                        SubCategory = "Competition",
                        VenueName = "The Branch ",
                        Street = "1501 Washington Ave",
                        City = "Racine",
                        State = "WI",
                        ZipCode = "53403"
                    });

        }
    }
}
