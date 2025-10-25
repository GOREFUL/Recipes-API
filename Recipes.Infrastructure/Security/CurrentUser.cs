using Microsoft.AspNetCore.Http;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories;
using System.Security.Claims;

namespace Recipes.Infrastructure.Security;
public class CurrentUser(IHttpContextAccessor http) : ICurrentUser
{
    public Guid? UserId
    {
        get
        {
            var id = http.HttpContext?.User?
                .FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(id, out var guid) ? guid : null;
        }
    }

    public bool IsInRole(string role) => 
        http.HttpContext?.User?.IsInRole(role) ?? false;
}
