namespace Recipes.Application.Dish.Dtos;
public class DishBasicDto(int Id, Guid CookId, string Name, string? Description, DateTime CreatedAt, bool IsFavorite)
{
    public int Id { get; } = Id;
    public Guid CookId { get; } = CookId;
    public string Name { get; } = Name;
    public string? Description { get; } = Description;
    public DateTime CreatedAt { get; } = CreatedAt;
    public bool IsFavorite { get; } = IsFavorite;

}