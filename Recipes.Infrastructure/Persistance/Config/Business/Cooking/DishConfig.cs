using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class DishConfig
    : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.ToTable("Dishes");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(d => d.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(d => d.Cook)
            .WithMany(u => u.Dishes)
            .HasForeignKey(d => d.CookId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(d => d.DishInfo)
        //    .WithOne(di => di.Dish)
        //    .HasForeignKey<Dish>(d => d.DishInfoId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
