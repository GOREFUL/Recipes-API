namespace Recipes.Application.Posts.Dtos;
public class PostDetailsDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int DishId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? MediaUrl { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}
