namespace Recipes.Domain.Repositories.Read;

public interface IMeasureUnitReadRepository
{
    Task<IReadOnlyList<int>> GetExistingIdsAsync(IEnumerable<int> ids, CancellationToken ct = default);
}
