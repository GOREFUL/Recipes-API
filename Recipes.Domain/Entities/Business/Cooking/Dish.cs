using Recipes.Domain.Entities.Business.Cooking.Links;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Business.Cooking;
public class Dish
{
    public int Id { get; set; }

    #region attributes
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    #endregion

    #region foreign keys
    public Guid CookId { get; set; }
    //public int DishInfoId { get; set; }
    #endregion

    #region one-to-one
    public DishInfo DishInfo { get; set; } = null!;
    #endregion

    #region many-to-one
    public ApplicationUser Cook { get; set; } = null!;
    #endregion

    #region one-to-many
    public ICollection<DishReport> Reports { get; set; } = new List<DishReport>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Plan> Plans { get; set; } = new List<Plan>();
    #endregion

    #region many-to-many
    public ICollection<FavoriteDish> Favorites { get; set; } = new List<FavoriteDish>();
    #endregion
}