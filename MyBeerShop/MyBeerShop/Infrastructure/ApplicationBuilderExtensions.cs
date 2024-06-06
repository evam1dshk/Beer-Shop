using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyBeerShop.Data;
using MyBeerShop.Data.Entities;
using MyBeerShop.Models.DataGenerator;

namespace MyBeerShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services
                .GetRequiredService<UserManager<Customer>>();

            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();


            var dbContext = services.GetRequiredService<MyBeerShopDbContext>();

            Task
                .Run(async () =>
                {
                    var users = DataGenerator.SeedUsers();
                    foreach (var customer in users)
                    {
                        if(!dbContext.Users.Any(x => x.Id == customer.Id))
                            await userManager.CreateAsync(customer);
                    }


                    var role = new IdentityRole { Name = "Admin" };

                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        await roleManager.CreateAsync(role);
                    }

                    var admin = await userManager.FindByNameAsync("admin@gmail.com");

                    await userManager.AddToRoleAsync(admin, role.Name);
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
