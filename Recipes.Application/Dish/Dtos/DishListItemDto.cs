namespace Recipes.Application.Dish.Dtos;
public class DishListItemDto(int Id, Guid UserId, string Name, string? Description, DateTime CreatedAd, bool IsFavorite)
{
    public int Id { get; } = Id;
    public Guid UserId { get; } = UserId;
    public string Name { get; } = Name;
    public string? Description { get; } = Description;
    public DateTime CreatedAd { get; } = CreatedAd;
    public bool IsFavorite { get; } = IsFavorite;
}
