using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Social;

namespace Recipes.Infrastructure.Persistance.Config.Business.Social;
public class SocialDataConfig
    : IEntityTypeConfiguration<SocialData>
{
    public void Configure(EntityTypeBuilder<SocialData> builder)
    {
        builder.ToTable("SocialData");
        builder.HasKey(sd => sd.Id);

        builder.Property(sd => sd.Likes)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(sd => sd.Dislikes)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasOne(sd => sd.Post)
            .WithOne(p => p.SocialData)
            .HasForeignKey<SocialData>(sd => sd.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
