using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManager.Models;

namespace UniversityManager.Helper
{
    public class SeederDatabase
    {
        public static void SeedData()
        {
            var context = new ApplicationDbContext();
            SeedUsers(context);
        }
        private static void SeedUsers(ApplicationDbContext _context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            if (!roleManager.Roles.Any())
            {
                IdentityRole roleAdmin = new IdentityRole()
                {
                    Name = "Admin",
                };
                IdentityRole roleStudent = new IdentityRole()
                {
                    Name = "Student",
                };
                IdentityRole roleTeacher = new IdentityRole()
                {
                    Name = "Teacher",
                };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleStudent);
                roleManager.Create(roleTeacher);
            }
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            if (!userManager.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };

                userManager.Create(user, "Qwerty-1");
                userManager.AddToRole(user.Id, "Admin");
            }
            //ApplicationUser user1 = new ApplicationUser()
            //{
            //    UserName = "admin1@gmail.com",
            //    Email = "admin1@gmail.com",
            //};

            //userManager.Create(user1, "Qwerty-1");
            //userManager.AddToRole(user1.Id, "Admin");
        }
    }
}