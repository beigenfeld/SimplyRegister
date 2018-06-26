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

            new Company { companyName = "GC Co., Inc.", mainContactEmail = "help@gcone.com", companyMembershipLevel = "Corporate" };

            new Company { companyName = "Associate Co., Inc.", mainContactEmail = "help@associateone.com", companyMembershipLevel = "Associate" };

            new Company { companyName = "CBA Co., Inc.", mainContactEmail = "help@cbaone.com", companyMembershipLevel = "CBA" };

            new Company { companyName = "IAP Co., Inc.", mainContactEmail = "help@iapone.com", companyMembershipLevel = "IAP" };

            new Company { companyName = "NonMember Co., Inc.", mainContactEmail = "help@nonone.com", companyMembershipLevel = "Non-Member" };
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
