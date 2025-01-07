using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductReviewAPI.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var adminRole = new IdentityRole
            {
                Id = "ad-role",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityRole
            {
                Id = "us-role",
                Name = "User",
                NormalizedName = "USER"
            };

            builder.HasData(adminRole, userRole);
        }
    }
}
