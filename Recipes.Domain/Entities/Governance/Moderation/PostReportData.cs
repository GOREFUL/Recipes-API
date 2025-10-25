using Recipes.Domain.Entities.Governance.Enumeration;
using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Governance.Moderation;
public class PostReportData
{
    public long Id { get; set; }

    #region one-to-one
    public Guid ModeratorId { get; set; }
    public long ReportId { get; set; }
    public short StatusId { get; set; }
    #endregion

    #region one-to-one
    public PostReport Report { get; set; } = null!;
    #endregion

    #region many-to-many
    public ApplicationUser Moderator { get; set; } = null!;
    public ReportStatus Status { get; set; } = null!;
    #endregion
}
