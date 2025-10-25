using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IIngredientUnitRepository
{
    Task AddRangeAsync(IEnumerable<IngredientUnit> units, CancellationToken token);
}
