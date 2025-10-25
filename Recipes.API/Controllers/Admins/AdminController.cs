using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Users.Identity;

namespace Recipes.API.Controllers.Admins;
[ApiController]
[Route("api/admin")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
public sealed class AdminController(IMediator mediator) : ControllerBase
{
    [HttpPost("users/{id:guid}/promote")]
    public async Task<IActionResult> Promote(Guid id, CancellationToken ct)
    {
        await mediator.Send(new PromoteUserToAdminCommand(id), ct);
        return NoContent();
    }
}
