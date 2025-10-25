using MediatR;
using Recipes.Application.Dish.Dtos;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;

namespace Recipes.Application.Dish.Queries.GetDishByIdWithDetails;
public class GetDishByIdWithDetailsQueryHandler
    (ICurrentUser current, IDishRepository repo)
    : IRequestHandler<GetDishByIdWithDetailsQuery, DishDetailsDto>
{
    public async Task<DishDetailsDto> Handle(GetDishByIdWithDetailsQuery q, CancellationToken token)
    {
        var d = await repo.GetByIdWithDetailsAsync(q.Id, token);
        if (d is null) throw new KeyNotFoundException($"Dish {q.Id} not found");

        var isFav = current.UserId.HasValue
            ? await repo.IsFavoriteAsync(current.UserId.Value, d.Id, token)
            : false;

        var info = d.DishInfo!;

        return new DishDetailsDto(
            d.Id,
            d.CookId,
            d.Name,
            d.Description,
            d.CreatedAt,
            info.LevelId,
            info.Time,
            info.Yield,
            info.ServingSize,
            string.IsNullOrWhiteSpace(info.Note) ? null : info.Note,
            info.Images.Select(i => i.Url).ToList(),
            info.IngredientUnits.Select(u => (u.IngredientId, u.MeasurementUnitId, u.Value)).ToList(),
            info.Allergies.Select(a => a.Name).ToList(),
            info.Cuisines.Select(c => c.Name).ToList(),
            info.Macronutrients is null
                ? null
                : (ValueTuple<double, double, double, double>?)(
                    (
                        (double)(info.Macronutrients.Kcal ?? 0),
                        (double)(info.Macronutrients.Protein ?? 0),
                        (double)(info.Macronutrients.SaturatedFat ?? 0),
                        (double)(info.Macronutrients.TransFat ?? 0)
                    )
                ),
            isFav
        );
    }
}