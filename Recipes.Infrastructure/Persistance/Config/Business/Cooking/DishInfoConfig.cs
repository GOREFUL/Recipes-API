using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class DishInfoConfig : IEntityTypeConfiguration<DishInfo>
{
    public void Configure(EntityTypeBuilder<DishInfo> builder)
    {
        builder.ToTable("DishInfos");
        builder.HasKey(di => di.Id);

        builder.Property(di => di.Time)
            .IsRequired();

        builder.Property(di => di.Yield)
            .IsRequired();

        builder.Property(di => di.ServingSize)
            .IsRequired();

        builder.Property(di => di.Note)
            .HasMaxLength(1000);

        builder.HasOne(di => di.Dish)
            .WithOne(d => d.DishInfo)
            .HasForeignKey<DishInfo>(di => di.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(di => di.Level)
            .WithMany(l => l.DishInfo)
            .HasForeignKey(di => di.LevelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
