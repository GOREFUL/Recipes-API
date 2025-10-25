using Recipes.Domain.Entities.Governance.Report;

namespace Recipes.Domain.Entities.Governance.Enumeration;
public class PostReportClass
{
    public short Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region many-to-one
    public ICollection<PostReport> Reports { get; set; } = new List<PostReport>();
    #endregion
}
