namespace Recipes.Domain.Entities.Business.Cooking;
public class Step
{
    public long Id { get; set; }

    #region attributes
    public byte Number { get; set; }
    public string ShortDescription { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    #endregion

    #region foreign keys
    public int DishInfoId { get; set; }
    #endregion

    #region many-to-one
    public DishInfo DishInfo { get; set; } = null!;
    #endregion
}
