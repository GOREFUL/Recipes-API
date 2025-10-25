using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Dish.Commands.Create;
using Recipes.Application.Dish.Dtos;

namespace Recipes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("dishes")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDishDto dto, CancellationToken ct)
    {
        var id = await mediator.Send(new CreateDishCommand(dto), ct);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }


    // заглушка під майбутній GET
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) => NotFound();
}
