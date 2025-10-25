using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking.Advanced;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking.Advanced;
public class MacronutrientsConfig
    : IEntityTypeConfiguration<Macronutrients>
{
    public void Configure(EntityTypeBuilder<Macronutrients> builder)
    {
        builder.ToTable("Macronutrients");
        builder.HasKey(e => e.Id);

        #region Attributes
        builder.Property(e => e.Kcal)
            .IsRequired(false);

        builder.Property(e => e.SaturatedFat)
            .IsRequired(false);

        builder.Property(e => e.TransFat)
            .IsRequired(false);

        builder.Property(e => e.Sugars)
            .IsRequired(false);

        builder.Property(e => e.Fiber)
            .IsRequired(false);

        builder.Property(e => e.Protein)
            .IsRequired(false);

        builder.Property(e => e.Salt)
            .IsRequired(false);

        builder.HasOne(e => e.DishInfo)
            .WithOne(d => d.Macronutrients)
            .HasForeignKey<Macronutrients>(e => e.DishInfoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}
