using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Recipes.Application.Users.Dtos.Auth;
using Recipes.Application.Users.Dtos.Login;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Application.Users.Commands.Login;
public class LoginCommandHandler
    (ILogger<LoginCommandHandler> logger,
    UserManager<ApplicationUser> userManager,
    IJwtTokenService jwt, IMapper mapper)
    : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling LoginCommand for {Email}", request.Payload.Email);
        var dto = request.Payload;
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null || user.IsDeleted)
        {
            logger.LogWarning("Login failed for {Email}: user not found or is deleted", dto.Email);
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var passOk = await userManager.CheckPasswordAsync(user, dto.Password);
        if (!passOk)
        {
            logger.LogWarning("Login failed for {Email}: incorrect password", dto.Email);
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var (token, expires) = await jwt.CreateAsync(user);
        var roles = (await userManager.GetRolesAsync(user)).ToArray();

        var auth = new AuthResult
        {
            User = user,
            Roles = roles,
            AccessToken = token,
            Expires = expires
        };

        return mapper.Map<LoginResponse>(auth);
    }
}
