using System.Text.Json.Serialization;

namespace Recipes.Infrastructure.Auth;
public class JwtOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    [JsonPropertyName("Key")]
    public string Key { get; set; } = default!;
    public int AccessTokenExpirationMinutes { get; set; } = 60;
}
