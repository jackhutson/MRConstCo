namespace MrConstruction.Migrations {
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

            //foreach(var role in Enum.GetNames(typeof(Roles))) {
            if (rm.RoleExists(Role.Admin)) {
                rm.Create(new IdentityRole(Role.Admin));
            };
            if (rm.RoleExists(Role.Contractor)) {
                rm.Create(new IdentityRole(Role.Contractor));
            }
            //}


            context.SaveChanges();

        }
    }
}
