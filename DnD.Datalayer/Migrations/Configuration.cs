using DnD.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DnD.Datalayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DnD.Datalayer.Context.DnDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DnD.Datalayer.Context.DnDContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(AuthorizationConstants.AdminRole))
            {
                roleManager.Create(new IdentityRole(AuthorizationConstants.AdminRole));
            }

            if (!roleManager.RoleExists(AuthorizationConstants.UserRole))
            {
                roleManager.Create(new IdentityRole(AuthorizationConstants.UserRole));
            }

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
