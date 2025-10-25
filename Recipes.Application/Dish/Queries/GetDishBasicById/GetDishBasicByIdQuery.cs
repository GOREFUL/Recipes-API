using MediatR;
using Recipes.Application.Dish.Dtos;

namespace Recipes.Application.Dish.Queries.GetDishBasicById;
public class GetDishBasicByIdQuery(int Id) : IRequest<DishBasicDto>
{
    public int Id { get; } = Id;
}
