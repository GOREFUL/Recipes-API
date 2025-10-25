using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Entities.Business.Cooking;
public class IngredientUnit
{
    public long Id { get; set; }

    #region attributes
    public float Value { get; set; }
    #endregion

    #region foreign keys
    public int DishInfoId { get; set; }
    public int IngredientId { get; set; }
    public int MeasurementUnitId { get; set; }
    #endregion

    #region many-to-one
    public DishInfo DishInfo { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
    public MeasurementUnit MeasurementUnit { get; set; } = null!;
    #endregion
}
