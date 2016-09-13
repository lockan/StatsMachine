namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<statsmachine.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(statsmachine.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var rolestore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);

            // Seed Roles table
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var admin = new IdentityRole { Name = "Admin" };
                rolemanager.Create(admin);
            }

            if (!context.Roles.Any(r => r.Name == "Organizer"))
            {
                var organizer = new IdentityRole { Name = "Organizer" };
                rolemanager.Create(organizer);
            }

            // Seed Users Table with default admin user
            var adminuser = new ApplicationUser
            {
                UserName = "andrew@test.com",
                firstname = "andrew",
                lastname = "lockhart", 
                avatar = "Protectorate"
            };

            if (!(context.Users.Any(u => u.UserName == "andrew@test.com")))
            {
                userManager.Create(adminuser, "P@ssw0rd");
            }

            // Assign default admin to "Admin" and "Organizer" roles
            if ((context.Users.Any(u => u.UserName == "andrew@test.com")))
            {
                var adminid = userManager.FindByName("andrew@test.com").Id;
                userManager.AddToRole(adminid, "Admin");
                userManager.AddToRole(adminid, "Organizer");
            }

            // Seed Games Table
            context.Games.AddOrUpdate(
                g => g.name, new Game { name = "Warmachine" }
            );
        }
    }
}
