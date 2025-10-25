using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public class IngredientUnitRepository : EfRepositoryBase<IngredientUnit>, IIngredientUnitRepository
{
    public IngredientUnitRepository(RecipesDbContext db) : base(db) { }
    public Task AddRangeAsync(IEnumerable<IngredientUnit> units, CancellationToken token) 
        => Set.AddRangeAsync(units, token);
}
