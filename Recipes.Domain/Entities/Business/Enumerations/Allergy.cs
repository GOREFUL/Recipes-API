using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Entities.Business.Enumerations;
public class Allergy
{
    public int Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region many-to-one
    public ICollection<DishInfo> DishInfos { get; set; } = new List<DishInfo>();
    #endregion
}
