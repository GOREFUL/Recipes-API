using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface IDishTagRepository
{
    Task AddAsync(DishTag e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<IReadOnlyList<DishTag>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken token);
    Task<(IReadOnlyList<DishTag>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}
