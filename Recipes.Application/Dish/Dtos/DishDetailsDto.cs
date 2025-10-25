namespace Recipes.Application.Dish.Dtos;
public class DishDetailsDto(int Id, Guid CookId, string Name, string? Description, DateTime CreatedAt, 
    int LevelId, TimeSpan Time, byte Yield, short ServingSize, string? Note, IReadOnlyList<string> ImageUrls, 
    IReadOnlyList<(int IngredientId, int MeasureUnitId, float Value)> Ingredients, IReadOnlyList<string> Allergies, 
    IReadOnlyList<string> Cuisines, (double Calories, double Proteins, double Fats, double Carbs)? Macros, bool IsFavorite)
{
    public int Id { get; } = Id;
    public Guid CookId { get; } = CookId;
    public string Name { get; } = Name;
    public string? Description { get; } = Description;
    public DateTime CreatedAt { get; } = CreatedAt;
    public int LevelId { get; } = LevelId;
    public TimeSpan Time { get; } = Time;
    public byte Yield { get; } = Yield;
    public short ServingSize { get; } = ServingSize;
    public string? Note { get; } = Note;
    public IReadOnlyList<string> ImageUrls { get; } = ImageUrls;
    public IReadOnlyList<(int IngredientId, int MeasureUnitId, float Value)> Ingredients { get; } = Ingredients;
    public IReadOnlyList<string> Allergies { get; } = Allergies;
    public IReadOnlyList<string> Cuisines { get; } = Cuisines;
    public (double Calories, double Proteins, double Fats, double Carbs)? Macros { get; } = Macros;
    public bool IsFavorite { get; } = IsFavorite;
}