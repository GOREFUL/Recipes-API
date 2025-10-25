using Recipes.Domain.Entities.Business.Cooking.Advanced;
using Recipes.Domain.Repositories.Business.Cooking.Advanced;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking.Advanced;
public class MacronutrientsRepository : EfRepositoryBase<Macronutrients>, IMacronutrientsRepository
{
    public MacronutrientsRepository(RecipesDbContext db) : base(db) { }
    public Task AddAsync(Macronutrients macro, CancellationToken token)
        => Set.AddAsync(macro, token).AsTask();
}
