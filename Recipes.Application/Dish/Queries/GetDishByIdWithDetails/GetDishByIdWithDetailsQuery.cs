using MediatR;
using Recipes.Application.Dish.Dtos;

namespace Recipes.Application.Dish.Queries.GetDishByIdWithDetails;
public class GetDishByIdWithDetailsQuery(int Id) : IRequest<DishDetailsDto>
{
    public int Id { get; } = Id;
}
