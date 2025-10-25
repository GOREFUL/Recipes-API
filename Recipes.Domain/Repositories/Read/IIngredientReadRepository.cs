namespace Recipes.Domain.Repositories.Read;

public interface IIngredientReadRepository
{
    Task<IReadOnlyList<int>> GetExistingIdsAsync(IEnumerable<int> ids, CancellationToken ct = default);
}
