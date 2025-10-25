using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking.Links;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking.Links;
public class FavoriteDishConfig
    : IEntityTypeConfiguration<FavoriteDish>
{
    public void Configure(EntityTypeBuilder<FavoriteDish> builder)
    {
        builder.ToTable("FavoriteDishes");
        builder.HasKey(fd => fd.Id);
        builder.HasIndex(fd => new { fd.UserId, fd.DishId })
            .IsUnique();

        builder.HasOne(fd => fd.User)
            .WithMany(u => u.FavoriteDishes)
            .HasForeignKey(fd => fd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(fd => fd.Dish)
            .WithMany(d => d.Favorites)
            .HasForeignKey(fd => fd.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex (fd => new {fd.UserId, fd.AddedAtUtc});
    }
}
