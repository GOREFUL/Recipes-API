using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Recipes.Application.Users.Dtos.Auth;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Application.Users.Queries.GetMyAuthProfile;
public class GetMyAuthProfileQueryHandler
    (ILogger<GetMyAuthProfileQueryHandler> logger, ICurrentUser current,
    UserManager<ApplicationUser> users, IMapper mapper)
    : IRequestHandler<GetMyAuthProfileQuery, AuthProfileDto>
{
    public async Task<AuthProfileDto> Handle(GetMyAuthProfileQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting auth profile for user {UserId}", current.UserId);
        if(current.UserId is null)
        {
            logger.LogWarning("No UserId found in the current context.");
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var user = await users.FindByIdAsync(current.UserId.Value.ToString());
        if(user is null)
        {
            logger.LogWarning("User with ID {UserId} not found.", current.UserId);
            throw new KeyNotFoundException($"User with ID {current.UserId} not found.");
        }

        var roles = (await users.GetRolesAsync(user)).ToArray();

        var auth = new AuthResult
        {
            User = user,
            Roles = roles
        };

        return mapper.Map<AuthProfileDto>(auth);

    }
}
