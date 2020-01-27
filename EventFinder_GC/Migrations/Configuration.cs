namespace EventFinder_GC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventFinder_GC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventFinder_GC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Hosts.AddOrUpdate(

            new Models.Host
            {
                FirstName = "Kee",
                LastName = "Cha"

            },

            new Models.Host
            {
                FirstName = "Bryce",
                LastName = "Sickles"
            },

            new Models.Host
            {
                FirstName = "Archana",
                LastName = "Karmakar"
            },

            new Models.Host
            {
                FirstName = "Matthew",
                LastName = "Patterson"
            });

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data.
        }
    }
}
