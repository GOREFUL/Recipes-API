using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Infrastructure.Persistance.Config.Business.Enumerations;
public class CuisineConfig
    : IEntityTypeConfiguration<Cuisine>
{
    public void Configure(EntityTypeBuilder<Cuisine> builder)
    {
        builder.ToTable("Cuisines");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasMany(c => c.DishInfos)
            .WithMany(d => d.Cuisines)
            .UsingEntity<Dictionary<string, object>>(
                "DishInfoCuisine",
                j => j.HasOne<DishInfo>()
                    .WithMany()
                    .HasForeignKey("DishInfoId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Cuisine>()
                    .WithMany()
                    .HasForeignKey("CuisineId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("DishInfoId", "CuisineId");
                    j.ToTable("DishInfoCuisines");
                }
            );
    }
}
