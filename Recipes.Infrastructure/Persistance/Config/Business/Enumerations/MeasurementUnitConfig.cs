using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Infrastructure.Persistance.Config.Business.Enumerations;
public class MeasurementUnitConfig
    : IEntityTypeConfiguration<MeasurementUnit>
{
    public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
    {
        builder.ToTable("MeasurementUnits");
        builder.HasKey(mu => mu.Id);
        builder.Property(mu => mu.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
