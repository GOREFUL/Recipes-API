using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Governance.Enumeration;
using Recipes.Domain.Entities.Governance.Moderation;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Governance.Report;
public class DishReport
{
    public long Id { get; set; }

    #region attributes
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    #endregion

    #region foreign keys
    public Guid UserId { get; set; }
    public int DishId { get; set; }
    public short ClassId { get; set; }
    #endregion

    #region one-to-one
    public DishReportData Data { get; set; } = null!;
    #endregion

    #region many-to-one
    public ApplicationUser User { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
    public DishReportClass Class { get; set; } = null!;
    #endregion
}
