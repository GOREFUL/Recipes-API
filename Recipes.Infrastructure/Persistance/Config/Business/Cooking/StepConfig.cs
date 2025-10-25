using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class StepConfig
    : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ToTable("Steps");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number)
            .IsRequired();

        builder.Property(e => e.ShortDescription)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.FullDescription)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasOne(e => e.DishInfo)
            .WithMany(d => d.Steps)
            .HasForeignKey(e => e.DishInfoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
