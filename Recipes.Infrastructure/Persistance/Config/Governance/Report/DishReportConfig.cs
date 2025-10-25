using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Report;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Report;
public class DishReportConfig
    : IEntityTypeConfiguration<DishReport>
{
    public void Configure(EntityTypeBuilder<DishReport> builder)
    {
        builder.ToTable("DishReports");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
            .HasMaxLength(2000);

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(u => u.DishReports)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Dish)
            .WithMany(d => d.Reports)
            .HasForeignKey(e => e.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Class)
            .WithMany(c => c.Reports)
            .HasForeignKey(e => e.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
