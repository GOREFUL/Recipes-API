using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Enumeration;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Enumeration;
public class DishReportClassConfig
    : IEntityTypeConfiguration<DishReportClass>
{
    public void Configure(EntityTypeBuilder<DishReportClass> builder)
    {
        builder.ToTable("DishReportClasses");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
