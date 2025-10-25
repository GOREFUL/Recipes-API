using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Entities.Business.Cooking.Links;
public class FavoriteDish
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int DishId { get; set; }
    public DateTime AddedAtUtc { get; set; } = DateTime.UtcNow;

    public ApplicationUser User { get; set; } = null!;
    public Dish Dish { get; set; } = null!;
}
