using MediatR;
using Recipes.Application.Users.Dtos.Login;

namespace Recipes.Application.Users.Commands.Login;
public class LoginCommand(LoginRequest payload) : IRequest<LoginResponse>
{
    public LoginRequest Payload { get; } = payload;
}
