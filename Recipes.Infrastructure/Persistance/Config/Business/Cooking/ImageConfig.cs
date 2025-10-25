using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Infrastructure.Persistance.Config.Business.Cooking;
public class ImageConfig
    : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(i => i.Description)
            .HasMaxLength(500);

        builder.HasOne(i => i.DishInfo)
            .WithMany(di => di.Images)
            .HasForeignKey(i => i.DishInfoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
