namespace SimplyRegister.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimplyRegister.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimplyRegister.Models.ApplicationDbContext";
        }

        protected override void Seed(SimplyRegister.Models.ApplicationDbContext context)
        {

            new Company { companyName = "GC One", mainContactEmail = "help@gcone.com", companyMembershipLevel = "Corporate" };

            new Company { companyName = "Associate One", mainContactEmail = "help@associateone.com", companyMembershipLevel = "Associate" };

            new Company { companyName = "CBA One", mainContactEmail = "help@cbaone.com", companyMembershipLevel = "CBA" };

            new Company { companyName = "IAP One", mainContactEmail = "help@iapone.com", companyMembershipLevel = "IAP" };

            new Company { companyName = "Non One", mainContactEmail = "help@nonone.com", companyMembershipLevel = "Non-Member" };
            //  This method will be called after migrating to the latest version.

//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//  to avoid creating duplicate seed data. E.g.
//
//    context.People.AddOrUpdate(
//      p => p.FullName,
//      new Person { FullName = "Andrew Peters" },
//      new Person { FullName = "Brice Lambson" },
//      new Person { FullName = "Rowan Miller" }
//    );
//
        }
    }
}
