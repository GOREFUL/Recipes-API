namespace Recipes.Domain.Entities.Business.Cooking.Advanced;
public class Micronutrients
{
    public int Id { get; set; }

    #region attributes
    public float? Sodium { get; set; }
    public float? Calcium { get; set; }
    public float? Iron { get; set; }
    public float? VitaminD { get; set; }
    public float? Potassium { get; set; }
    #endregion

    #region foreign keys
    public int DishInfoId { get; set; }
    #endregion

    #region one-to-one
    public DishInfo DishInfo { get; set; } = null!;
    #endregion one-to-one
}
