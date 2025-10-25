using MediatR;
using Recipes.Application.Dish.Dtos;

namespace Recipes.Application.Dish.Queries.GetMyDishes;
public class GetMyDishesQuery(string? Name = null, int Page = 1, int PageSize = 20)
  : IRequest<IReadOnlyList<DishListItemDto>>
{
    public string? Name { get; } = Name;
    public int Page { get; } = Page;
    public int PageSize { get; } = PageSize;
}
