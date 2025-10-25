namespace Recipes.Domain.Entities.Business.Cooking.Advanced;
public class Macronutrients
{
    public int Id { get; set; }

    #region attributes
    public short? Kcal { get; set; }
    public float? SaturatedFat { get; set; }
    public float? TransFat { get; set; }
    public float? Sugars { get; set; }
    public float? Fiber { get; set; }
    public float? Protein { get; set; }
    public float? Salt { get; set; }
    #endregion

    #region foreign keys
    public int DishInfoId { get; set; }
    #endregion

    #region one-to-one
    public DishInfo DishInfo { get; set; } = null!;
    #endregion
}
