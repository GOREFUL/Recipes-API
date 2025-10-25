using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Users.Dtos;
using Recipes.Domain.Repositories.System;

namespace Recipes.Application.Users.Commands.CreateUser;
public class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
    IMapper mapper, IIdentityRepository identity)
    :IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new user with email {Email}",
            request.Payload.Email);

        if (await identity.EmailExistsAsync(request.Payload.Email,
            cancellationToken))
        {
            logger.LogWarning("User with email {Email} already exists",
                request.Payload.Email);
            throw new InvalidOperationException(
                $"User with email {request.Payload.Email} already exists.");
        }

        var (userId, error) = await identity.CreateUserAsync(
            request.Payload.Email,
            request.Payload.Password,
            request.Payload.DisplayName,
            cancellationToken);

        if (!string.IsNullOrEmpty(error))
        {
            logger.LogError("Error creating user with email {Email}: {Error}",
                request.Payload.Email, error);
            throw new InvalidOperationException(
                $"Error creating user: {error}");
        }

        var user = await identity.FindByIdAsync(userId,
            cancellationToken) ?? throw new KeyNotFoundException(
                "User not found after creation.");

        return mapper.Map<UserDto>(user);
    }
}
