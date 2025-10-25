using MediatR;
using Recipes.Application.Dish.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Queries.GetMyDishes;
public sealed class GetMyDishesQueryHandler
    (ICurrentUser current, IDishRepository repo)
    : IRequestHandler<GetMyDishesQuery, IReadOnlyList<DishListItemDto>>
{
    public async Task<IReadOnlyList<DishListItemDto>> Handle(GetMyDishesQuery q, CancellationToken token)
    {
        if (!current.UserId.HasValue) throw new UnauthorizedAccessException();

        var items = await repo.GetMyAsync(current.UserId.Value, q.Page, q.PageSize, q.Name, token);

        var result = new List<DishListItemDto>(items.Count);
        foreach (var d in items)
        {
            var fav = await repo.IsFavoriteAsync(current.UserId.Value, d.Id, token);
            result.Add(new DishListItemDto(d.Id, d.CookId, d.Name, d.Description, d.CreatedAt, fav));
        }
        return result;
    }
}