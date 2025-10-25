using Recipes.Domain.Entities.Governance.Enumeration;
using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Governance.Moderation;
public class CommentReportData
{
    public long Id { get; set; }

    #region one-to-one
    public Guid ModeratorId { get; set; }
    public long ReportId { get; set; }
    public short StatusId { get; set; }
    #endregion

    #region one-to-one
    public CommentReport Report { get; set; } = null!;
    #endregion

    #region many-to-one
    public ApplicationUser Moderator { get; set; } = null!;
    public ReportStatus Status { get; set; } = null!;
    #endregion
}
