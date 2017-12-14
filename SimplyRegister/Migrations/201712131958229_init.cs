namespace SimplyRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        companyId = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        mainContactEmail = c.String(),
                        companyMembershipLevel = c.String(),
                    })
                .PrimaryKey(t => t.companyId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        customerCompany = c.Int(nullable: false),
                        clcMember = c.Boolean(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                        companyId = c.Int(),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.customerId)
                .ForeignKey("dbo.Companies", t => t.companyId)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.companyId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.Int(nullable: false, identity: true),
                        eventName = c.String(),
                        eventDate = c.DateTime(nullable: false),
                        eventType = c.String(),
                        corporatePrice = c.Double(nullable: false),
                        assocaitePrice = c.Double(nullable: false),
                        cbaPrice = c.Double(nullable: false),
                        iapPrice = c.Double(nullable: false),
                        nonMemberPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.eventId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        registrationId = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        eventId = c.Int(nullable: false),
                        amountBilled = c.Double(nullable: false),
                        amountPaid = c.Double(nullable: false),
                        invoiceRequested = c.Boolean(nullable: false),
                        invoiceSent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.registrationId)
                .ForeignKey("dbo.Customers", t => t.customerId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.eventId, cascadeDelete: true)
                .Index(t => t.customerId)
                .Index(t => t.eventId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsAdmin = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.EventCustomers",
                c => new
                    {
                        Event_eventId = c.Int(nullable: false),
                        Customer_customerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_eventId, t.Customer_customerId })
                .ForeignKey("dbo.Events", t => t.Event_eventId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_customerId, cascadeDelete: true)
                .Index(t => t.Event_eventId)
                .Index(t => t.Customer_customerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Customers", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Registrations", "eventId", "dbo.Events");
            DropForeignKey("dbo.Registrations", "customerId", "dbo.Customers");
            DropForeignKey("dbo.EventCustomers", "Customer_customerId", "dbo.Customers");
            DropForeignKey("dbo.EventCustomers", "Event_eventId", "dbo.Events");
            DropForeignKey("dbo.Customers", "companyId", "dbo.Companies");
            DropIndex("dbo.EventCustomers", new[] { "Customer_customerId" });
            DropIndex("dbo.EventCustomers", new[] { "Event_eventId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Registrations", new[] { "eventId" });
            DropIndex("dbo.Registrations", new[] { "customerId" });
            DropIndex("dbo.Customers", new[] { "userId" });
            DropIndex("dbo.Customers", new[] { "companyId" });
            DropTable("dbo.EventCustomers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Registrations");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
        }
    }
}
