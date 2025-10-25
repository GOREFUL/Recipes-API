using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Business.Social;
public class Comment
{
    public long Id { get; set; }

    #region attributes
    public string Text { get; set; } = string.Empty;
    public int Likes { get; set; }
    public DateTime CreatedAt { get; set; }
    #endregion

    #region foreign keys
    public Guid UserId { get; set; }
    public int PostId { get; set; }
    #endregion

    #region many-to-one
    public ApplicationUser User { get; set; } = null!;
    public Post Post { get; set; } = null!;
    #endregion

    #region one-to-many
    public ICollection<CommentReport> Reports { get; set; }
        = new List<CommentReport>();
    #endregion
}
