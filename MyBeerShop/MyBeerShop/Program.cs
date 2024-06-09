using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data;
using MyBeerShop.Data.Entities;
using MyBeerShop.Infrastructure;
using MyBeerShop.Models.DataGenerator;
using MyBeerShop.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyBeerShopDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Customer>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<MyBeerShopDbContext>();

builder.Services.AddTransient<IPasswordHasher<Customer>, PasswordHasher<Customer>>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.SeedAdmin();

app.Run();