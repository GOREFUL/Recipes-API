using MediatR;

namespace Recipes.Application.Users.Commands.DeleteUser;
public class DeleteUserCommand(Guid userId) : IRequest<Unit>
{
    public Guid UserId { get; } = userId;
}
