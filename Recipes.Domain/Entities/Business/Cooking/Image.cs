namespace Recipes.Domain.Entities.Business.Cooking;
public class Image
{
    public long Id { get; set; }

    #region attributes
    //public byte[] Data { get; set; } = Array.Empty<byte>();
    public string Url { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    #endregion

    #region foreign keys
    public int DishInfoId { get; set; }
    #endregion

    #region many-to-one 
    public DishInfo DishInfo { get; set; } = null!;
    #endregion
}
