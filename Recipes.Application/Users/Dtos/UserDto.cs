namespace Recipes.Application.Users.Dtos;
public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime CreateAt { get; set; }
}
