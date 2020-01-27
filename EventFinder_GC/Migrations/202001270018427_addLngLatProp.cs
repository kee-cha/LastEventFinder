namespace EventFinder_GC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLngLatProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Longitude");
            DropColumn("dbo.Customers", "Latitude");
        }
    }
}
