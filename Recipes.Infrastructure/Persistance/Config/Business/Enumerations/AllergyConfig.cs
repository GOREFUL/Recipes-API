using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Infrastructure.Persistance.Config.Business.Enumerations;
public class AllergyConfig
    : IEntityTypeConfiguration<Allergy>
{
    public void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.ToTable("Allergies");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasMany(a => a.DishInfos)
            .WithMany(d => d.Allergies)
            .UsingEntity<Dictionary<string, object>>(
                "DishInfoAllergy",
                j => j.HasOne<DishInfo>()
                    .WithMany()
                    .HasForeignKey("DishInfoId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Allergy>()
                    .WithMany()
                    .HasForeignKey("AllergyId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("DishInfoId", "AllergyId");
                    j.ToTable("DishInfoAllergies");
                }
            );
    }
}
