using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Features.Lookups;
using Recipes.Application.Features.Lookups.Dto.Lookup;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetAllergyPage;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetCuisinePage;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetIngredientsPage;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetLevelsPage;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetMeasureUnitsPage;

namespace Recipes.API.Controllers;

[ApiController]
[Route("api/lookups")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public sealed class LookupsController(IMediator mediator) : ControllerBase
{
    [HttpGet("ingredients")]
    public Task<Paged<LookupItemDto>> GetIngredients([FromQuery] string? q, 
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetIngredientsPageQuery(q, page, pageSize), token);

    [HttpGet("measure-units")]
    public Task<Paged<LookupItemDto>> GetMeasureUnits([FromQuery] string? q,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetMeasureUnitsPageQuery(q, page, pageSize), token);

    [HttpGet("levels")]
    public Task<Paged<LookupItemDto>> GetLevels([FromQuery] string? q,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetLevelsPageQuery(q, page, pageSize), token);

    [HttpGet("allergies")]
    public Task<Paged<LookupItemDto>> GetAllergies([FromQuery] string? q,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetAllergyPageQuery(q, page, pageSize), token);

    [HttpGet("cuisines")]
    [ProducesResponseType(typeof(Paged<LookupItemDto>), StatusCodes.Status200OK)]
    public Task<Paged<LookupItemDto>> GetCuisines([FromQuery] string? q,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken token = default)
    {
         var result = mediator.Send(new GetCuisinePageQuery(q, page, pageSize), token);
        return result;
    }
}
