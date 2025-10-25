using MediatR;
using Recipes.Application.Users.Dtos;

namespace Recipes.Application.Users.Commands.CreateUser;
public class CreateUserCommand(UserCreateDto payload) : IRequest<UserDto>
{
    public UserCreateDto Payload { get; } = payload;
}
