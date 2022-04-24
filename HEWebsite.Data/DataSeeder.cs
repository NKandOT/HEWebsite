using HEWebsite.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEWebsite.Data
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _services;

        public DataSeeder(ApplicationDbContext context, IServiceProvider services)
        {
            _context = context;
            _services = services;
        }

        public async Task SeedAdmin()
        {
            var roleManager = _services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _services.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser 
            {
                DisplayName = "HEWebsiteAdmin",
                UserName = "380592@students.chesterfield.ac.uk",
                Email = "380592@students.chesterfield.ac.uk",
                EmailConfirmed = true,
                LockoutEnabled = false,
                MemberSince = DateTime.UtcNow,
                Id = IdBuilder()
            };

            var hasAdminRole = _context.Roles.Any(roles => roles.Name == "Admin");

            if (!hasAdminRole)
            {
                var result1 = await roleManager.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                });
            }


            var hasAdmin = _context.Users.Any(u => u.Email == user.Email);

            if (!hasAdmin)
            {
                var result2 = await userManager.CreateAsync(user, "Password!23") ;
                await _context.SaveChangesAsync();
                var result3 = await userManager.AddToRoleAsync(user, "Admin");
            }

            await _context.SaveChangesAsync();
        }
        private string IdBuilder()
        {
            Random random = new Random();
            int stringleng = 36;
            int randvalue;
            string id = "";
            char letter;

            for (int i = 0; i < stringleng; i++)
            {
                randvalue = random.Next(0, 26);
                letter = Convert.ToChar(randvalue + 65);
                id += letter;
            }
            return id;
        }
    }
}
