using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Read;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Read;
public class MeasureUnitReadRepository : EfRepositoryBase<MeasurementUnit>, IMeasureUnitReadRepository
{
    public MeasureUnitReadRepository(RecipesDbContext db) : base(db) { }
    public async Task<IReadOnlyList<int>> GetExistingIdsAsync(IEnumerable<int> ids, CancellationToken ct = default)
    {
        var set = ids.Distinct().ToArray();
        if (set.Length == 0) return Array.Empty<int>();
        return await Set.AsNoTracking().Where(x => set.Contains(x.Id)).Select(x => x.Id).ToListAsync(ct);
    }
}
