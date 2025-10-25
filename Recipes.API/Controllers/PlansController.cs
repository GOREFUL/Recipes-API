using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Planing.Command.CreatePlan;
using Recipes.Application.Planing.Command.DeletePlan;
using Recipes.Application.Planing.Command.UpdatePlan;
using Recipes.Application.Planing.Dtos;
using Recipes.Application.Planing.Queries.GetPlanById;
using Recipes.Application.Planing.Queries.GetPlanByIdWithDish;
using Recipes.Application.Planing.Queries.GetPlansRange;

namespace Recipes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PlansController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PlanDto>> Create([FromBody] CreatePlanDto dto, CancellationToken ct)
        => Ok(await mediator.Send(new CreatePlanCommand(dto), ct));

    [HttpGet("{id:long}")]
    public async Task<ActionResult<PlanListItemDto>> GetById(long id, CancellationToken ct)
        => Ok(await mediator.Send(new GetPlanByIdQuery(id), ct));

    [HttpGet("{id:long}/details")]
    public async Task<ActionResult<PlanDto>> GetByIdDetails(long id, CancellationToken ct)
        => Ok(await mediator.Send(new GetPlanByIdWithDishQuery(id), ct));

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PlanListItemDto>>> GetRange([FromQuery] DateOnly from, [FromQuery] DateOnly to, CancellationToken ct)
        => Ok(await mediator.Send(new GetPlansRangeQuery(from, to), ct));

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdatePlanDto dto, CancellationToken ct)
    {
        await mediator.Send(new UpdatePlanCommand(id, dto), ct);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken ct)
    {
        await mediator.Send(new DeletePlanCommand(id), ct);
        return NoContent();
    }
}
