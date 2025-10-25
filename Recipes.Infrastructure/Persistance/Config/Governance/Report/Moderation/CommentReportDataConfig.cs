using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Moderation;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Report.Moderation;
public class CommentReportDataConfig
    : IEntityTypeConfiguration<CommentReportData>
{
    public void Configure(EntityTypeBuilder<CommentReportData> builder)
    {
        builder.ToTable("CommentReportData");
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Moderator)
            .WithMany(u => u.ModeratedCommentReports)
            .HasForeignKey(e => e.ModeratorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Report)
            .WithOne(r => r.Data)
            .HasForeignKey<CommentReportData>(e => e.ReportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Status)
            .WithMany(s => s.CommentReportsData)
            .HasForeignKey(e => e.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
