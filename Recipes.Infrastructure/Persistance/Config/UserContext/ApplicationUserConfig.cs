using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Infrastructure.Persistance.Config.UserContext;
public class ApplicationUserConfig
    : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.DisplayName)
            .IsRequired()
            .HasMaxLength(64);
        builder.Property(e => e.AvatarUrl)
            .HasMaxLength(512);
        builder.Property(e => e.Bio)
            .HasMaxLength(1024);
        builder.Property(e => e.CreateAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        // for faster lookup by display name
        builder.HasIndex(p => p.DisplayName);
    }
}
