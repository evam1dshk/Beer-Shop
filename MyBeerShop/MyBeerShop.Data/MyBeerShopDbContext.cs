using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBeerShop.Data.Entities;
using static System.Net.WebRequestMethods;

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
                new BeerType { Id = 2, Name = "Ale" }
            );


            builder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 1,
                    BeerName = "Hornbeer",
                    ImageUrl = "https://winevybe.com/wp-content/uploads/Hornbeer-Hornbeer-Happy-Hoppy-Viking.png",
                    Description = "Dark beer",
                    Price = 8.0M,
                    Producer = "HornBeer",
                    CriticScore = "71/100",
                    AlcoholBV = "9.30%",
                    TestingNotes = "\r\nBrown, full-bodied, cloudy, very strongly hopped, caramel malt notes, grapefruity, dried fruits, syrupy, light cocoa notes, spicy",
                    Packaging = "Bottle",
                    BeerTypeId = 1
                },

                 new Beer
                 {
                     Id = 2,
                     BeerName = "Pohjoisen panimo Maistila",
                     ImageUrl = "https://winevybe.com/wp-content/uploads/Pohjoisen-panimo-Maistila-Maistila-Aprikoi-Saison.png",
                     Description = "A strong beer.",
                     Price = 4.0M,
                     Producer = "Pohjoisen panimo Maistila",
                     CriticScore = "68/100",
                     AlcoholBV = "6.60%",
                     TestingNotes = "Orange-yellow, medium-bodied, cloudy, with a rich head, mildly hopped, apricot notes, fruity",
                     Packaging = "Bottle",
                     BeerTypeId = 2
                 }
            );

           /* builder.Entity<Customer>().HasData(
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
            );*/
        }
    }
}