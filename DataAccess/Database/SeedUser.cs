using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DataAccess.Database
{
    public static class SeedUser
    {
        public static void AddSeedUser(this ModelBuilder modelBuilder)
        {

            const string userId = "0f8fad5b-d9cb-469f-a165-70867728950e";
            const string roleId = "0f8za25b-t9cb-469f-a165-708677289502";

            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@gmail.com",
                NormalizedEmail = "admin@GMAIL.COM"
            };

            var ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin1234");

            var role = new ApplicationRole()
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Rank = 1
            };

            var userRole = new ApplicationUserRole()
            {
                RoleId = roleId,
                UserId = userId
            };

            //var claimList = SeedClaims.Claims.Select(c => new IdentityRoleClaim<string>() { ClaimType = c.Type, ClaimValue = c.Value }).ToList();

            var listOfClaims = new List<IdentityRoleClaim<string>>();
            int counter = 1;
            foreach (var t in SeedClaims.Claims)
            {
                listOfClaims.Add(new IdentityRoleClaim<string>()
                {
                    Id = counter,
                    RoleId = roleId,
                    ClaimValue = t.Value,
                    ClaimType = t.Type,
                });
                counter++;
            }


            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<ApplicationRole>().HasData(role);
            modelBuilder.Entity<ApplicationUserRole>().HasData(userRole);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(listOfClaims);
        }
    }
}
