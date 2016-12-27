namespace Events.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class DbMigartionsConfig : DbMigrationsConfiguration<Events.Data.ApplicationDbContext>
    {
        public DbMigartionsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Events.Data.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminEmail = "admin@adming.com";
                var adminUserName = adminEmail;
                var adminFullName = "System Administrator";
                var adminPassword = adminEmail;
                string adminRole = "Administrator";
                CreateAdminUser(context, adminEmail, adminUserName, adminFullName, adminPassword, adminRole);
                CreateSeveralEvents(context);
            }
        }

        private void CreateSeveralEvents(ApplicationDbContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Party @ Softuni",
                StartDateTime = DateTime.Now.AddDays(5).AddHours(21).AddMinutes(30),
                Author = context.Users.First()
            });

            context.Events.Add(new Event()
            {
                Title = "Passed Event <Anonymous>",
                StartDateTime = DateTime.Now.AddDays(-2).AddHours(10).AddMinutes(30),
                Duration = TimeSpan.FromHours(1.5),
                Comments = new HashSet<Comment>()
                {
                    new Comment() { Text = "<Anonymous> Comment" },
                    new Comment() { Text = "User comment", Author = context.Users.First()}
                }
            });
        }

        private void CreateAdminUser(ApplicationDbContext context, string adminEmail, string adminUserName, string adminFullName, string adminPassword, string adminRole)
        {
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                FullName = adminFullName,
                Email = adminEmail
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join(";", userCreateResult.Errors));
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join(";", userCreateResult.Errors));
            }

            var addAdminRolseResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRolseResult.Succeeded)
            {
                throw new Exception(string.Join(";", userCreateResult.Errors));
            }
        }
    }
}
