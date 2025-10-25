using Recipes.Domain.Entities.Governance.Moderation;

namespace Recipes.Domain.Entities.Governance.Enumeration;
public class ReportStatus
{
    public short Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region many-to-one
    public ICollection<DishReportData> DishReportsData { get; set; } 
        = new List<DishReportData>();
    public ICollection<PostReportData> PostReportsData { get; set; } 
        = new List<PostReportData>();
    public ICollection<CommentReportData> CommentReportsData { get; set; } 
        = new List<CommentReportData>();
    #endregion
}
