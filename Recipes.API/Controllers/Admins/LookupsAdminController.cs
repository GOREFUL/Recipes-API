using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateAllergy;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateCuisine;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateIngredient;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateMeasureUnit;
using Recipes.Application.Features.Lookups.Dto.CreateDtos;

namespace Recipes.API.Controllers.Admins;

[ApiController]
[Route("api/admin/lookups")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
public sealed class LookupsAdminController(IMediator mediator) : ControllerBase
{
    [HttpPost("levels")]
    public Task<int> CreateLevel(CreateLevelDto dto, CancellationToken token)
        => mediator.Send(new CreateLevelCommand(dto), token);

    [HttpPost("ingredients")]
    public Task<int> CreateIngredient(CreateIngredientDto dto, CancellationToken token)
        => mediator.Send(new CreateIngredientCommand(dto), token);

    [HttpPost("measure-units")]
    public Task<int> CreateMeasureUnit(CreateMeasureUnitDto dto, CancellationToken token)
        => mediator.Send(new CreateMeasureUnitCommand(dto), token);

    [HttpPost("allergies")]
    public Task<int> CreateAllergy(CreateAllergyDto dto, CancellationToken token)
        => mediator.Send(new CreateAllergyCommand(dto), token);

    [HttpPost("cuisines")]
    public Task<int> CreateCuisine(CreateCuisineDto dto, CancellationToken token)
        => mediator.Send(new CreateCuisineCommand(dto), token);
}

