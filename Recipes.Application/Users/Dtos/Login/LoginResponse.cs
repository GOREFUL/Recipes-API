namespace Recipes.Application.Users.Dtos.Login;
public class LoginResponse
{
    public string AccessToken { get; set; } = default!;
    public string TokenType { get; set; } = "Bearer";
    public DateTime Expires { get; set; }

    public UserDto User { get; set; } = default!;
    public string[] Roles { get; set; } = Array.Empty<string>();
}
