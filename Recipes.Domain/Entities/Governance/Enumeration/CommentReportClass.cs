using Recipes.Domain.Entities.Governance.Report;

namespace Recipes.Domain.Entities.Governance.Enumeration;
public class CommentReportClass
{
    public short Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region many-to-one
    public ICollection<CommentReport> Reports { get; set; } = new List<CommentReport>();
    #endregion
}
