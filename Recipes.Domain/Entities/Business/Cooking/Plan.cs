using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Business.Cooking;
public class Plan
{
    public long Id { get; set; }

    #region attributes
    public TimeSpan TimePoint { get; set; }
    public byte Yield { get; set; }
    public string Note { get; set; } = string.Empty;
    #endregion

    #region foreign keys
    public Guid UserId { get; set; }
    public int DishId { get; set; }
    #endregion

    #region many-to-one
    public ApplicationUser Cook { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
    #endregion
}
