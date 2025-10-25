using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Recipes.API.Auth;

public class SelfOrAdminHandler
    : AuthorizationHandler<SelfOrAdminRequirement, Guid>
{
    protected override Task HandleRequirementAsync
        (AuthorizationHandlerContext context, 
        SelfOrAdminRequirement requirement, 
        Guid resource)
    {
        if (context.User.IsInRole("Admin"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim != null && Guid.TryParse(userIdClaim, out var userId))
        {
            if (userId == resource)
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}
