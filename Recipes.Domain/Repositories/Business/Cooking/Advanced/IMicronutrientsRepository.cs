using Recipes.Domain.Entities.Business.Cooking.Advanced;

namespace Recipes.Domain.Repositories.Business.Cooking.Advanced;

public interface IMicronutrientsRepository
{
    Task AddAsync(Micronutrients micro, CancellationToken token);
}
