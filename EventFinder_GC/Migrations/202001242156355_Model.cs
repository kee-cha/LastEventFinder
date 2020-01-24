namespace EventFinder_GC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ArtInterest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "SportInterest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "FoodInterest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MusicInterest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "TechInterest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "TechInterest");
            DropColumn("dbo.Customers", "MusicInterest");
            DropColumn("dbo.Customers", "FoodInterest");
            DropColumn("dbo.Customers", "SportInterest");
            DropColumn("dbo.Customers", "ArtInterest");
        }
    }
}
