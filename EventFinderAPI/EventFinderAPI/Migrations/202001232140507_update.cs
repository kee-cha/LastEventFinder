namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "HostId", c => c.Int());
            AlterColumn("dbo.Events", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "HostId", c => c.Int(nullable: false));
        }
    }
}
