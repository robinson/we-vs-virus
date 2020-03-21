using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WeVsVirus.Business.Utility
{
    public static class DatabaseInitializer
    {
        public static void InitializeSeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(AccessRoles.ApiUser).Result)
            {
                var role = new IdentityRole(AccessRoles.ApiUser);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(AccessRoles.WebClientUser).Result)
            {
                var role = new IdentityRole(AccessRoles.WebClientUser);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(AccessRoles.HealthOfficeUser).Result)
            {
                var role = new IdentityRole(AccessRoles.HealthOfficeUser);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(AccessRoles.DriverUser).Result)
            {
                var role = new IdentityRole(AccessRoles.DriverUser);
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}