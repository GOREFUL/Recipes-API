namespace Recipes.Application.Users.Dtos.Auth;
public class AuthProfileDto
{
    public UserDto User { get; init; } = default!;
    public string[] Roles { get; init; } = System.Array.Empty<string>();
}
