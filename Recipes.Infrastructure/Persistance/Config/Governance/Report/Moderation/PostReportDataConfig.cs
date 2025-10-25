using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Moderation;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Report.Moderation;
public class PostReportDataConfig
    : IEntityTypeConfiguration<PostReportData>
{
    public void Configure(EntityTypeBuilder<PostReportData> builder)
    {
        builder.ToTable("PostReportData");
        builder.HasKey(prd => prd.Id);
        
        builder.HasOne(prd => prd.Moderator)
            .WithMany(u => u.ModeratedPostReports)
            .HasForeignKey(prd => prd.ModeratorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(prd => prd.Report)
            .WithOne(pr => pr.Data)
            .HasForeignKey<PostReportData>(prd => prd.ReportId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(prd => prd.Status)
            .WithMany(rs => rs.PostReportsData)
            .HasForeignKey(prd => prd.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
