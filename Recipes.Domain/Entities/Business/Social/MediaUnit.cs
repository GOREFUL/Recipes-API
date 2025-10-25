namespace Recipes.Domain.Entities.Business.Social;
// this Video
public class MediaUnit
{
    public int Id { get; set; }

    #region attributes
    //public byte[] Data { get; set; } = Array.Empty<byte>();
    public string Url { get; set; } = string.Empty;
    #endregion

    #region foreign keys
    public int PostId { get; set; }
    #endregion

    #region one-to-one
    public Post Post { get; set; } = null!;
    #endregion
}
