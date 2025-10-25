using MediatR;
using Recipes.Application.Dish.Dtos;

namespace Recipes.Application.Dish.Commands.Create;
public class CreateDishCommand(CreateDishDto dto) : IRequest<int>
{
    public CreateDishDto Dto { get; } = dto;
}
