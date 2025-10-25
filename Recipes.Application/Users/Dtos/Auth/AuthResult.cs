using Recipes.Domain.Entities.UserContext;

namespace Recipes.Application.Users.Dtos.Auth;
public class AuthResult
{
    public ApplicationUser User { get; set; } = default!;
    public string[] Roles { get; set; } = Array.Empty<string>();
    public string AccessToken { get; set; } = default!;
    public DateTime Expires { get; set; }
}
