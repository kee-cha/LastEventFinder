namespace EventFinderAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressIntoEventAPIModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        VenueName = c.String(),
                        Date = c.String(),
                        Category = c.String(),
                        SubCategory = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
