namespace Recipes.Domain.Entities.Business.Social;
public class SocialData
{
    public int Id { get; set; }

    #region attributes
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    #endregion

    #region foreign keys
    public int PostId { get; set; }
    #endregion

    #region one-to-one
    public Post Post { get; set; } = null!;
    #endregion
}
