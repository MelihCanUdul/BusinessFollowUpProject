using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BusinessFollowUpProject.Web
{
    public  static class IdentityInitializer
    {

        public static async System.Threading.Tasks.Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });

            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });

            }
            var adminUser = await userManager.FindByNameAsync("Melih");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Melih",
                    SurName = "Udül",
                    UserName = "Melih",
                    Email = "melihh.2580@gmail.com"
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
    }
}
