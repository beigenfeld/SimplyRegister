namespace SimplyRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcustomertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        companyId = c.String(nullable: false, maxLength: 128),
                        companyName = c.String(),
                        mainContactEmail = c.String(),
                        companyMembershipLevel = c.String(),
                    })
                .PrimaryKey(t => t.companyId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(),
                        lastName = c.String(),
                        customerCompany = c.String(),
                        clcMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.customerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
        }
    }
}
