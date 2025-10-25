using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.UserContext;
using Recipes.Domain.Repositories.System;
using Recipes.Infrastructure.Persistance;
using System.Security.Claims;

namespace Recipes.Infrastructure.Repositories.System;
public class IdentityRepository
    (UserManager<ApplicationUser> users, IConfigurationProvider mapConfig,
    RecipesDbContext dbContext)
    : IIdentityRepository
{
    public async Task<(Guid userId, string? error)> CreateUserAsync
        (string email, string password, string displayName, 
        CancellationToken token = default)
    {
        var username = email.Split('@')[0];
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            DisplayName = displayName,
            CreateAt = DateTime.UtcNow
        };

        var result = await users.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return (Guid.Empty, 
                string.Join("; ", result.Errors.Select(e => e.Description)));
        }
        return (user.Id, null);
    }

    public async Task<bool> EmailExistsAsync
        (string email, CancellationToken token = default)
    {
        return await users.FindByEmailAsync(email) is not null;
    }

    public async Task<ApplicationUser?> FindByIdAsync
        (Guid id, CancellationToken token = default)
    {
        return await users.Users
            .FirstOrDefaultAsync(u => u.Id == id, token);
    }

    public async Task<bool> SoftDeleteAsync
        (Guid id, CancellationToken token = default)
    {
        var user = await users.Users
            .FirstOrDefaultAsync(u => u.Id == id, token);
        if (user is null)
            return false;

        user.IsDeleted = true;
        user.LockoutEnd = DateTimeOffset.MaxValue;
        await users.UpdateAsync(user);
        return true;
    }

    public async Task<Guid?> TryGetCurrentUserIdAsync(ClaimsPrincipal user, CancellationToken token)
    {
        var idStr = user.FindFirstValue(ClaimTypes.NameIdentifier) ??
            user.FindFirstValue("sub");

        if (!Guid.TryParse(idStr, out var id))
            return null;

        var result = await dbContext.Users.AnyAsync(u => u.Id == id, token);
        return result ? id : null;
    }
}
