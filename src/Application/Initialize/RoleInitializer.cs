using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web1.Infrastructure;

namespace Web1.Initialize
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<Peoplelogin> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            string adminEmail = "admin@admin";
            string password = "123456789";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("user"));
            }
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("moderator"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                Peoplelogin admin = new Peoplelogin { Email = adminEmail, UserName = "admin" };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
