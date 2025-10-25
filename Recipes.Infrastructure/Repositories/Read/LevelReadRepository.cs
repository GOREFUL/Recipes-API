using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Read;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Read;
public class LevelReadRepository : EfRepositoryBase<Level>, ILevelReadRepository
{
    public LevelReadRepository(RecipesDbContext db) : base(db) { }
    public Task<bool> ExistsAsync(int id, CancellationToken ct = default)
        => Set.AsNoTracking().AnyAsync(x => x.Id == id, ct);
}
