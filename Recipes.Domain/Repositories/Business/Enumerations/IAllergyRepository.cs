using Recipes.Domain.Entities.Business.Enumerations;
using System.Threading.Tasks;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface IAllergyRepository
{
    Task AddAsync(Allergy e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<IReadOnlyList<Allergy>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken token);
    Task<(IReadOnlyList<Allergy>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}
