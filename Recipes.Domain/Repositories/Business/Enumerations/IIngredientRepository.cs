using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface IIngredientRepository
{
    Task AddAsync(Ingredient e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<(IReadOnlyList<Ingredient>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}