using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IDishRepository
{
    Task AddAsync(Dish dish, CancellationToken token);
    Task<Dish?> GetByIdAsync(int id, CancellationToken token);
}
