using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReviewAPI.Entities;

namespace ProductReviewAPI.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            var adminUser1 = new User
            {
                Id = "a1-b2",
                UserName = "PrviAdmin",
                NormalizedUserName = "PRVIADMIN",
                Email = "admin1@example.com",
                NormalizedEmail = "ADMIN1@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Adminlozinka1")
            };

            var adminUser2 = new User
            {
                Id = "c1-d2",
                UserName = "DrugiAdmin",
                NormalizedUserName = "DRUGIADMIN",
                Email = "admin2@example.com",
                NormalizedEmail = "ADMIN2@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Adminlozinka2")
            };

            var normalUser1 = new User
            {
                Id = "e1-f2",
                UserName = "PrviUser",
                NormalizedUserName = "PRVIUSER",
                Email = "user1@example.com",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Userlozinka1")
            };

            var normalUser2 = new User
            {
                Id = "g1-h2",
                UserName = "DrugiUser",
                NormalizedUserName = "DRUGIUSER",
                Email = "user2@example.com",
                NormalizedEmail = "USER2@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Userlozinka2")
            };

            builder.HasData(adminUser1, adminUser2, normalUser1, normalUser2);
        }
    }
}
