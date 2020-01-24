namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDataTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Rating", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Rating", c => c.Int());
        }
    }
}
