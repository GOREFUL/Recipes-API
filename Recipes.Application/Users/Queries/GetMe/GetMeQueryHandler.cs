using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Users.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.System;

namespace Recipes.Application.Users.Queries.GetMe;
public class GetMeQueryHandler(ILogger<GetMeQueryHandler> logger,
    ICurrentUser current, IIdentityRepository identity, IMapper mapper)
    : IRequestHandler<GetMeQuery, UserDto>
{
    public async Task<UserDto> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {QueryName} for UserId: {UserId}",
            nameof(GetMeQuery), current.UserId);

        if (current.UserId is null)
        {
            logger.LogWarning("No UserId found in the current context.");
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var user = await identity.FindByIdAsync(current.UserId.Value,
            cancellationToken);

        return mapper.Map<UserDto>(user);
    }
}
