using Recipes.Domain.Entities.Business.Cooking.Advanced;

namespace Recipes.Domain.Repositories.Business.Cooking.Advanced;

public interface IMacronutrientsRepository
{
    Task AddAsync(Macronutrients macro, CancellationToken token);
}
