using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface ILevelRepository
{
    Task AddAsync(Level e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<(IReadOnlyList<Level> Items, int Total)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}
