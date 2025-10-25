using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Users.Commands.CreateUser;
using Recipes.Application.Users.Commands.DeleteUser;
using Recipes.Application.Users.Commands.Login;
using Recipes.Application.Users.Dtos;
using Recipes.Application.Users.Dtos.Login;
using Recipes.Application.Users.Queries.GetCurrentUserId;
using Recipes.Application.Users.Queries.GetMe;
using Recipes.Application.Users.Queries.GetUserById;

namespace Recipes.API.Controllers;

[ApiController]
[Route("api/identity")]
public class UserController(IMediator mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponse>> Login(
        [FromBody] Application.Users.Dtos.Login.LoginRequest request,
        CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var result = await mediator.Send(new LoginCommand(request), ct);

        if (result == null)
            return Unauthorized();

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Create([FromBody] UserCreateDto dto, CancellationToken ct)
    {
        var user = await mediator.Send(new CreateUserCommand(dto), ct);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetMe(CancellationToken ct)
        => Ok(await mediator.Send(new GetMeQuery(), ct));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id, CancellationToken ct)
        => Ok(await mediator.Send(new GetUserByIdQuery(id), ct));


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, [FromServices] IAuthorizationService auth, CancellationToken ct)
    {
        var res = await auth.AuthorizeAsync(User, id, "SelfOrAdmin");
        if (!res.Succeeded) return Forbid();
        await mediator.Send(new DeleteUserCommand(id), ct);
        return NoContent();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("my-id")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> GetMyId(CancellationToken token)
    {
        return Ok(await mediator.Send(new GetCurrentUserIdQuery(), token));
    }
}
