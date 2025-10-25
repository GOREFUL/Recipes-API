using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Repositories.System;

namespace Recipes.Application.Users.Commands.DeleteUser;
public class DeleteUserCommandHandler
    (ILogger<DeleteUserCommandHandler> logger, IIdentityRepository identity)
    : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting user with ID: {UserId}", request.UserId);
        var result = await identity
            .SoftDeleteAsync(request.UserId, cancellationToken);
        if (!result)
        {
            logger.LogWarning("Failed to delete user with ID: {UserId}", request.UserId);
            throw new KeyNotFoundException($"User with ID {request.UserId} could not be deleted.");
        }

        return Unit.Value;
    }
}
