namespace WebApplication5.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication5.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication5.Models.ApplicationDbContext context)
        {
             // ADD 3 TEST USERS WITH DIFFERENT ROLES
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if(!context.Users.Any(t => t.UserName == "admin@teacat.com"))
            {
                var user = new ApplicationUser { UserName = "admin@teacat.com", Email = "admin@teacat.com" };
                userManager.Create(user, "Passw0rd!");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "TCAdmin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "TCAdmin");
            }

            if (!context.Users.Any(t => t.UserName == "manager@teacat.com"))
            {
                var user = new ApplicationUser { UserName = "manager@teacat.com", Email = "manager@teacat.com" };
                userManager.Create(user, "Passw0rd!");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "TCManager" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "TCManager");
            }

            if (!context.Users.Any(t => t.UserName == "agent@teacat.com"))
            {
                var user = new ApplicationUser { UserName = "agent@teacat.com", Email = "agent@teacat.com" };
                userManager.Create(user, "Passw0rd!");

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "TCAgent" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "TCAgent");
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
