using MediatR;
using Recipes.Application.Dish.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Queries.GetDishBasicById;
public class GetDishBasicByIdQueryHandler
    (ICurrentUser current, IDishRepository repo)
    : IRequestHandler<GetDishBasicByIdQuery, DishBasicDto>
{
    public async Task<DishBasicDto> Handle(GetDishBasicByIdQuery q, CancellationToken token)
    {
        var d = await repo.GetByIdAsync(q.Id, token);
        if (d is null) throw new KeyNotFoundException($"Dish {q.Id} not found");

        var isFav = current.UserId.HasValue
            ? await repo.IsFavoriteAsync(current.UserId.Value, d.Id, token)
            : false;

        return new DishBasicDto(d.Id, d.CookId, d.Name, d.Description, d.CreatedAt, isFav);
    }
}
