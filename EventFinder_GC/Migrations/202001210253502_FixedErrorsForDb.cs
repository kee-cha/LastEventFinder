namespace EventFinder_GC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedErrorsForDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.AddressId)
                .Index(t => t.ApplicationId);
            
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
                        HostId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Hosts", t => t.HostId, cascadeDelete: true)
                .Index(t => t.HostId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        HostId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HostId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "HostId", "dbo.Hosts");
            DropForeignKey("dbo.Hosts", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Hosts", new[] { "ApplicationId" });
            DropIndex("dbo.Events", new[] { "AddressId" });
            DropIndex("dbo.Events", new[] { "HostId" });
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Hosts");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
