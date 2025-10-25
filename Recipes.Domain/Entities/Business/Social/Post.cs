using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Business.Social;
public class Post
{
    public int Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    #endregion

    #region foreign keys
    public Guid UserId { get; set; }
    public int DishId { get; set; }
    #endregion

    #region one-to-one
    public MediaUnit MediaUnit { get; set; } = null!;
    public SocialData SocialData { get; set; } = null!;
    #endregion

    #region one-to-many
    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();
    public ICollection<PostReport> Reports { get; set; }
        = new List<PostReport>();
    #endregion

    #region many-to-one
    public ApplicationUser User { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
    #endregion
}
