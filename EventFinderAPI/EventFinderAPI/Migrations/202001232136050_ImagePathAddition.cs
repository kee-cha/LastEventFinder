namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ImagePath");
        }
    }
}
