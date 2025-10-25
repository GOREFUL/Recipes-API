using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities.Governance.Enumeration;

namespace Recipes.Infrastructure.Persistance.Config.Governance.Enumeration;
public class PostReportClassConfig
    : IEntityTypeConfiguration<PostReportClass>
{
    public void Configure(EntityTypeBuilder<PostReportClass> builder)
    {
        builder.ToTable("PostReportClasses");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
