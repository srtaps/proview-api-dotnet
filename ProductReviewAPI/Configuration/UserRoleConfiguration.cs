using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductReviewAPI.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> { UserId = "a1-b2", RoleId = "ad-role" },
                new IdentityUserRole<string> { UserId = "c1-d2", RoleId = "ad-role" },
                new IdentityUserRole<string> { UserId = "e1-f2", RoleId = "us-role" },
                new IdentityUserRole<string> { UserId = "g1-h2", RoleId = "us-role" }
                );
        }
    }
}
