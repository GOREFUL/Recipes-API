namespace Recipes.Domain.Repositories.Read;

public interface ILevelReadRepository
{
    Task<bool> ExistsAsync(int id, CancellationToken ct = default);
}
