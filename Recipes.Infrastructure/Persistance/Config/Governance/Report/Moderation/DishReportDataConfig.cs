using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Moderation;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Report.Moderation;
public class DishReportDataConfig
    : IEntityTypeConfiguration<DishReportData>
{
    public void Configure(EntityTypeBuilder<DishReportData> builder)
    {
        builder.ToTable("DishReportData");
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Moderator)
            .WithMany(e => e.ModeratedDishReports)
            .HasForeignKey(e => e.ModeratorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Report)
            .WithOne(e => e.Data)
            .HasForeignKey<DishReportData>(e => e.ReportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Status)
            .WithMany(e => e.DishReportsData)
            .HasForeignKey(e => e.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
