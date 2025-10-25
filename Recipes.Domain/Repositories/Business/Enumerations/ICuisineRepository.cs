using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface ICuisineRepository
{
    Task AddAsync(Cuisine e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<IReadOnlyList<Cuisine>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
    Task<(IReadOnlyList<Cuisine>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}
