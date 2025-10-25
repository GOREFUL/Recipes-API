using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Repositories.Business.Social;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Social;
public class MediaUnitRepository : EfRepositoryBase<MediaUnit>, IMediaUnitRepository
{
    public MediaUnitRepository(RecipesDbContext db) : base(db) { }

    public Task AddAsync(MediaUnit media, CancellationToken token)
        => Set.AddAsync(media, token).AsTask();
}
