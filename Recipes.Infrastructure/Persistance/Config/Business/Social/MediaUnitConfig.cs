using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Social;

namespace Recipes.Infrastructure.Persistance.Config.Business.Social;
public class MediaUnitConfig
    : IEntityTypeConfiguration<MediaUnit>
{
    public void Configure(EntityTypeBuilder<MediaUnit> builder)
    {
        builder.ToTable("MediaUnits");
        builder.HasKey(mu => mu.Id);

        builder.Property(mu => mu.Url)
            .IsRequired()
            .HasMaxLength(2048);

        builder.HasOne(mu => mu.Post)
            .WithOne(p => p.MediaUnit)
            .HasForeignKey<MediaUnit>(mu => mu.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
