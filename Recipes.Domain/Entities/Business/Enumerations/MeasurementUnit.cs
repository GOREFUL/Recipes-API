using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Entities.Business.Enumerations;
public class MeasurementUnit
{
    public int Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    #endregion

    #region many-to-one
    public ICollection<IngredientUnit> IngredientUnits { get; set; }
        = new List<IngredientUnit>();
    #endregion
}
