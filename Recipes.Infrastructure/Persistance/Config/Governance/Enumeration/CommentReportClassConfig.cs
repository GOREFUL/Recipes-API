using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Enumeration;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Enumeration;
public class CommentReportClassConfig
    : IEntityTypeConfiguration<CommentReportClass>
{
    public void Configure(EntityTypeBuilder<CommentReportClass> builder)
    {
        builder.ToTable("CommentReportClasses");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
