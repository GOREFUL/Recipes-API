using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking.Advanced;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking.Advanced;
public class MicronutrientsConfig
    : IEntityTypeConfiguration<Micronutrients>
{
    public void Configure(EntityTypeBuilder<Micronutrients> builder)
    {
        builder.ToTable("Micronutrients");
        builder.HasKey(e => e.Id);

        #region Attributes
        builder.Property(e => e.Sodium)
            .IsRequired(false);

        builder.Property(e => e.Calcium)
            .IsRequired(false);

        builder.Property(e => e.Iron)
            .IsRequired(false);

        builder.Property(e => e.VitaminD)
            .IsRequired(false);

        builder.Property(e => e.Potassium)
            .IsRequired(false);

        builder.HasOne(e => e.DishInfo)
            .WithOne(d => d.Micronutrients)
            .HasForeignKey<Micronutrients>(e => e.DishInfoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}
