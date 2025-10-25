namespace Recipes.Application.Posts.Dtos;
public class CreatePostDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int DishId { get; set; }
    public string Url { get; set; } = default!;
}
