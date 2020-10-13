namespace CMFLMS.Migrations.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMFLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
            ContextKey = "CMFLMS.Models.ApplicationDbContext";
        }

        //protected override void Seed(CMFLMS.Models.ApplicationDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}

        protected override void Seed(ApplicationDbContext context)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //if (!roleManager.RoleExists("SuperAdmin"))//Can View, Create, Edit, Delete
            //{
            //    roleManager.Create(new IdentityRole("SuperAdmin"));
            //}
            //if (!roleManager.RoleExists("Admin"))// Can View & Create only
            //{
            //    roleManager.Create(new IdentityRole("Admin"));
            //}
            //if (!roleManager.RoleExists("User"))//Can View only
            //{
            //    roleManager.Create(new IdentityRole("User"));
            //}
            //if (!roleManager.RoleExists("MainAdmin"))
            //{
            //    roleManager.Create(new IdentityRole("MainAdmin"));
            //}
            ////if (!roleManager.RoleExists("TopAdmin"))
            ////{
            ////    roleManager.Create(new IdentityRole("TopAdmin"));
            ////}
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //string[] emails = { "s@s.s", "a@a.a", "u@u.u", "m@m.m" };
            //if (userManager.FindByEmail(emails[0]) == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        Email = emails[0],
            //        UserName = emails[0],
            //    };
            //    var result = userManager.Create(user, "123123");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "SuperAdmin");
            //    }
            //}
            //if (userManager.FindByEmail(emails[1]) == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        Email = emails[1],
            //        UserName = emails[1],
            //    };
            //    var result = userManager.Create(user, "123123");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            //    }
            //}
            //if (userManager.FindByEmail(emails[2]) == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        Email = emails[2],
            //        UserName = emails[2],
            //    };
            //    var result = userManager.Create(user, "123123");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "User");
            //    }
            //}
            //if (userManager.FindByEmail(emails[3]) == null)
            //{
            //    var user = new ApplicationUser
            //    {
            //        Email = emails[3],
            //        UserName = emails[3],
            //    };
            //    var result = userManager.Create(user, "123123");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "MainAdmin");
            //    }
            //}
        }
    }
}
