namespace SimplyRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpricelevelstoeventmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "corporatePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "assocaitePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "cbaPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "iapPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Events", "nonMemberPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "nonMemberPrice");
            DropColumn("dbo.Events", "iapPrice");
            DropColumn("dbo.Events", "cbaPrice");
            DropColumn("dbo.Events", "assocaitePrice");
            DropColumn("dbo.Events", "corporatePrice");
        }
    }
}
