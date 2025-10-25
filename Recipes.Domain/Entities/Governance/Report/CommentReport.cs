using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Entities.Governance.Enumeration;
using Recipes.Domain.Entities.Governance.Moderation;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Governance.Report;
public class CommentReport
{
    public long Id { get; set; }

    #region attributes
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    #endregion

    #region foreign keys
    public Guid UserId { get; set; }
    public long CommentId { get; set; }
    public short ClassId { get; set; }
    #endregion

    #region one-to-one
    public CommentReportData Data { get; set; } = null!;
    #endregion

    #region many-to-one
    public ApplicationUser User { get; set; } = null!;
    public Comment Comment { get; set; } = null!;
    public CommentReportClass Class { get; set; } = null!;
    #endregion
}
