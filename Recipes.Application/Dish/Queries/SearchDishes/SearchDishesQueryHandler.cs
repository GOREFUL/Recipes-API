using MediatR;
using Recipes.Application.Dish.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Queries.SearchDishes;
public sealed class SearchDishesQueryHandler
    (ICurrentUser current, IDishRepository repo)
    : IRequestHandler<SearchDishesQuery, IReadOnlyList<DishListItemDto>>
{
    public async Task<IReadOnlyList<DishListItemDto>> Handle(SearchDishesQuery q, CancellationToken token)
    {
        var tuples = await repo.SearchAsync(current.UserId, q.Page, q.PageSize, q.Name, token);
        return tuples.Select(t => new DishListItemDto(
            t.dish.Id, t.dish.CookId, t.dish.Name, t.dish.Description, t.dish.CreatedAt, t.isFavorite
        )).ToList();
    }
}