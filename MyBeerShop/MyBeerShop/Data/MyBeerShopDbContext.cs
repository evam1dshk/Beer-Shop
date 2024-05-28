using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data.Entities;

namespace MyBeerShop.Data
{
    public class MyBeerShopDbContext : IdentityDbContext<Customer>
    {
        public MyBeerShopDbContext(DbContextOptions<MyBeerShopDbContext> options)
            : base(options)
        {

        }
        public DbSet<Beer> Beers { get; set; } = null!;
        public DbSet<BeerType> BeerTypes { get; set; } = null!;
        public override DbSet<Customer> Users { get; set; }
        public DbSet<Cart> Carts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<Cart>()
                .HasOne(c => c.Beer)
                .WithMany(b => b.Carts)
                .HasForeignKey(c => c.BeerId);

            builder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.Carts)
                .HasForeignKey(c => c.CustomerId);

            // Seed data
            builder.Entity<BeerType>().HasData(
                new BeerType { Id = 1, Name = "Omnipollo" },
                new BeerType { Id = 2, Name = "Ale" },
                new BeerType { Id = 3, Name = "" }
            );

            var hasher = new PasswordHasher<Customer>();

            builder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 1,
                    BeerName = "Omnipollo",
                    ImageUrl = "image_url",
                    Description = "Citrus beer",
                    Price = 5.0M,
                    Producer = "Producer A",
                    CriticScore = "71/100",
                    AlcoholBV = "6.20%",
                    TestingNotes = "Lemon-yellow, full-bodied, cloudy, very strongly hopped, citrus notes, pomelo notes, currant leaf notes, light grassy notes, fresh, refreshing",
                    Packaging = "Bottle",
                    BeerTypeId = 1
                },

                 new Beer
                 {
                     Id = 2,
                     BeerName = "Ale Beer",
                     ImageUrl = "image_url",
                     Description = "A strong beer.",
                     Price = 6.0M,
                     Producer = "Producer B",
                     CriticScore = "66/100",
                     AlcoholBV = "6.0%",
                     TestingNotes = "Golden-yellow, full-bodied, strongly hopped, ripe fruit notes, malt biscuit notes, light grapefruit notes, herbal notes, balanced",
                     Packaging = "Bottle",
                     BeerTypeId = 2
                 }
            );

            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = "BC4219EA-6BE7-47E2-8D2C-A0740BED3151",
                    UserName = "guest",
                    NormalizedUserName = "GUEST",
                    Email = "guest@gmail.com",
                    NormalizedEmail = "GUEST@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "guest123")
                },
                new Customer
                {
                    Id = "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "admin123")
                }
            );
        }
    }
}