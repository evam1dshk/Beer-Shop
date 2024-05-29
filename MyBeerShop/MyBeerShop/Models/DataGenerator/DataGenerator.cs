using Microsoft.AspNetCore.Identity;


namespace MyBeerShop.Models.DataGenerator
{
    public class DataGenerator
    {
        public const string DefaultPassword = "123456";

        public static IEnumerable<IdentityUser> SeedUsers()
        {
            IEnumerable<IdentityUser> users = new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    Id = "BC4219EA-6BE7-47E2-8D2C-A0740BED3151",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM"
                },
                new IdentityUser()
                {
                    Id = "5F23C81D-9B0C-48BD-AC91-DDD4FB6D2DDA",
                    UserName = "guest@gmail.com",
                    NormalizedUserName = "GUEST@GMAIL.COM",
                    Email = "guest@gmail.com",
                    NormalizedEmail = "GUEST@GMAIL.COM"
                }
            };

            var hasher = new PasswordHasher<IdentityUser>();
            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, DefaultPassword);
            }

            return users;
        }
    }
}
