namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHostIdAndRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "HostId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Rating");
            DropColumn("dbo.Events", "HostId");
        }
    }
}
