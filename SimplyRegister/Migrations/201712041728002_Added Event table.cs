namespace SimplyRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventId = c.String(nullable: false, maxLength: 128),
                        eventName = c.String(),
                        eventDate = c.DateTime(nullable: false),
                        eventType = c.String(),
                    })
                .PrimaryKey(t => t.eventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
