using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class PlanConfig
    : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.TimePoint)
            .IsRequired();

        builder.Property(e => e.Yield)
            .IsRequired();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Note)
            .HasMaxLength(2048)
            .IsRequired(false);

        builder.HasOne(e => e.Cook)
            .WithMany(u => u.Plans)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Dish)
            .WithMany(d => d.Plans)
            .HasForeignKey(e => e.DishId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
