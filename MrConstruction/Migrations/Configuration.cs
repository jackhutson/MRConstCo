namespace MrConstruction.Migrations {
    using Domain;
    using Domain.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MrConstruction.Infrastructure.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MrConstruction.Infrastructure.ApplicationDbContext context) {
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

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var um = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            if (!rm.RoleExists(Role.Admin)) {
                rm.Create(new IdentityRole(Role.Admin));
            }
            if (!rm.RoleExists(Role.Contractor)) {
                rm.Create(new IdentityRole(Role.Contractor));
            }
            context.SaveChanges();

            var mike = um.FindByName("mcon@gmail.com");
            if (mike == null) {
                mike = new ApplicationUser() {
                    UserName = "mcon@gmail.com",
                    Email = "mcon@gmail.com"
                };
                um.Create(mike, "Bang!1");
            }

            if (!um.IsInRole(mike.Id, Role.Admin)) {
                um.AddToRole(mike.Id, Role.Admin);
            }
        }
    }
}
