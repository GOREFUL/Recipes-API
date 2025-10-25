using Recipes.Domain.Entities.UserContext;
using System.Security.Claims;

namespace Recipes.Domain.Repositories.System;

public interface IIdentityRepository
{
    Task<Guid?> TryGetCurrentUserIdAsync(ClaimsPrincipal user, CancellationToken token);

    Task<bool> EmailExistsAsync(string email,
        CancellationToken token = default);

    Task<(Guid userId, string? error)> CreateUserAsync(string email,
        string password, string displayName,
        CancellationToken token = default);

    Task<ApplicationUser?> FindByIdAsync(Guid id,
        CancellationToken token = default);

    Task<bool> SoftDeleteAsync(Guid id, CancellationToken token = default);
}
