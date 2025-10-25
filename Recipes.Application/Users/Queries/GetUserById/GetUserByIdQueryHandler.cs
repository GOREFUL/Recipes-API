using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Users.Dtos;
using Recipes.Domain.Repositories.System;

namespace Recipes.Application.Users.Queries.GetUserById;
public class GetUserByIdQueryHandler
    (ILogger<GetUserByIdQueryHandler> logger, IIdentityRepository identity,
    IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {QueryName} for UserId: {UserId}",
            nameof(GetUserByIdQuery), request.UserId);
        var user = await identity.FindByIdAsync(request.UserId,
            cancellationToken);
        return mapper.Map<UserDto>(user);
    }
}
