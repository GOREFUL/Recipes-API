using Recipes.Domain.Entities.UserContext;

namespace Recipes.Domain.Abstractions;

public interface IJwtTokenService
{
    Task<(string token, DateTime expires)> CreateAsync
        (ApplicationUser user, CancellationToken ct = default);
}
