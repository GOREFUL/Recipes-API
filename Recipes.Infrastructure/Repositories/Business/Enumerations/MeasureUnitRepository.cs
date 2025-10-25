using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Enumerations;
public class MeasureUnitRepository : EfRepositoryBase<MeasurementUnit>, IMeasureUnitRepository
{
    public MeasureUnitRepository(RecipesDbContext db) : base(db) { }

    public Task AddAsync(MeasurementUnit e, CancellationToken token)
        => Set.AddAsync(e, token).AsTask();

    public Task<bool> ExistsByNameAsync(string name, CancellationToken token)
    {
        var n = (name ?? "").Trim();
        return Set.AsNoTracking().AnyAsync(x => x.Name.ToLower() == n.ToLower(), token);
    }

    public async Task<(IReadOnlyList<MeasurementUnit>, int)> GetPageAsync(string? q, int page, int size, CancellationToken token)
    {
        page = page <= 0 ? 1 : page;
        size = size <= 0 ? 20 : size;

        var query = Set.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(q))
        {
            var s = q.Trim();
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{s}%"));
        }

        var total = await query.CountAsync(token);
        var items = await query
            .OrderBy(x => x.Name)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(token);

        return (items, total);
    }
}