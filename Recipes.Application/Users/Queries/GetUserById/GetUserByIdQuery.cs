using MediatR;
using Recipes.Application.Users.Dtos;

namespace Recipes.Application.Users.Queries.GetUserById;
public class GetUserByIdQuery(Guid userId) : IRequest<UserDto>
{
    public Guid UserId { get; } = userId;
}
