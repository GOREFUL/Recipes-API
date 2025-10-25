using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class IngredientUnitConfig
    : IEntityTypeConfiguration<IngredientUnit>
{
    public void Configure(EntityTypeBuilder<IngredientUnit> builder)
    {
        builder.ToTable("IngredientUnits");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Value)
            .IsRequired();
    
        builder.HasOne(e => e.DishInfo)
            .WithMany(d => d.IngredientUnits)
            .HasForeignKey(e => e.DishInfoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Ingredient)
            .WithMany(i => i.IngredientUnits)
            .HasForeignKey(e => e.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.MeasurementUnit)
            .WithMany(m => m.IngredientUnits)
            .HasForeignKey(e => e.MeasurementUnitId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
