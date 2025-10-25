namespace Recipes.Application.Users.Dtos;
public class UserCreateDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
}
