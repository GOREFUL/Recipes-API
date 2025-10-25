using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Infrastructure.Persistance.Config.Business.Enumerations;
public class DishTagConfig
    : IEntityTypeConfiguration<DishTag>
{
    public void Configure(EntityTypeBuilder<DishTag> builder)
    {
        builder.ToTable("DishTags");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasMany(t => t.DishInfos)
            .WithMany(d => d.Tags)
            .UsingEntity<Dictionary<string, object>>(
                "DishInfoTag",
                j => j.HasOne<DishInfo>()
                    .WithMany()
                    .HasForeignKey("DishInfoId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<DishTag>()
                    .WithMany()
                    .HasForeignKey("DishTagId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("DishInfoId", "DishTagId");
                    j.ToTable("DishInfoTags");
                }
            );
    }
}
