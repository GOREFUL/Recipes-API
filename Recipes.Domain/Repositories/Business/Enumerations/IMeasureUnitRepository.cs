using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Enumerations;

public interface IMeasureUnitRepository
{
    Task AddAsync(MeasurementUnit e, CancellationToken token);
    Task<bool> ExistsByNameAsync(string name, CancellationToken token);
    Task<(IReadOnlyList<MeasurementUnit>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token);
}
