using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Repositories.System;

namespace Recipes.Application.Users.Queries.GetCurrentUserId;
public class GetCurrentUserIdQueryHandler(ILogger<GetCurrentUserIdQueryHandler> logger,
    IHttpContextAccessor accessor, IIdentityRepository identity)
    : IRequestHandler<GetCurrentUserIdQuery, Guid?>
{
    public async Task<Guid?> Handle(GetCurrentUserIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetCurrentUserIdQuery");
        var principal = accessor.HttpContext?.User
            ?? throw new UnauthorizedAccessException("No HTTP context available");

        var id = await identity.TryGetCurrentUserIdAsync(principal, cancellationToken);
        if (id is null)
        {
            logger.LogWarning("No current user ID found");
            throw new UnauthorizedAccessException("User is not authenticated.");
        }
        else
        {
            logger.LogInformation("Current user ID: {UserId}", id);
            return id;
        }
    }
}
