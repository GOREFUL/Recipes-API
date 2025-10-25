using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Entities.Business.Enumerations;
public class Level
{
    public int Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region one-to-many
    public ICollection<DishInfo> DishInfo { get; set; }
        = new List<DishInfo>();
    #endregion
}
