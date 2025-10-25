using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Dish.Commands.AddFavoriteDish;
using Recipes.Application.Dish.Commands.Create;
using Recipes.Application.Dish.Commands.DeleteDish;
using Recipes.Application.Dish.Commands.RemoveFavoriteDish;
using Recipes.Application.Dish.Dtos;
using Recipes.Application.Dish.Queries.GetDishBasicById;
using Recipes.Application.Dish.Queries.GetDishByIdWithDetails;
using Recipes.Application.Dish.Queries.GetMyDishes;
using Recipes.Application.Dish.Queries.SearchDishes;

namespace Recipes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost("dishes")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDishDto dto, CancellationToken token)
    {
        var id = await mediator.Send(new CreateDishCommand(dto), token);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(DishBasicDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<DishBasicDto> GetById(int id, CancellationToken token)
        => mediator.Send(new GetDishBasicByIdQuery(id), token);

    [HttpGet("{id:int}/details")]
    [ProducesResponseType(typeof(DishDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Task<DishDetailsDto> GetByIdWithDetails(int id, CancellationToken token)
        => mediator.Send(new GetDishByIdWithDetailsQuery(id), token);

    [HttpGet("my")]
    [ProducesResponseType(typeof(IReadOnlyList<DishListItemDto>), StatusCodes.Status200OK)]
    public Task<IReadOnlyList<DishListItemDto>> My([FromQuery] string? name, [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new GetMyDishesQuery(name, page, pageSize), token);

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DishListItemDto>), StatusCodes.Status200OK)]
    public Task<IReadOnlyList<DishListItemDto>> Search([FromQuery] string? name, [FromQuery] int page = 1, 
        [FromQuery] int pageSize = 20, CancellationToken token = default)
        => mediator.Send(new SearchDishesQuery(name, page, pageSize), token);

    [HttpPost("{id:int}/favorite")]
    public async Task<IActionResult> AddFavorite(int id, CancellationToken token)
    {
        await mediator.Send(new AddFavoriteDishCommand(id), token);
        return NoContent();
    }

    [HttpDelete("{id:int}/favorite")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveFavorite(int id, CancellationToken ct)
    {
        await mediator.Send(new RemoveFavoriteDishCommand(id), ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await mediator.Send(new DeleteDishCommand(id), token);
        return NoContent();
    }
}
