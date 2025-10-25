using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Repositories.Business.Social;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Social;
public class SocialDataRepository : EfRepositoryBase<SocialData>, ISocialDataRepository
{
    public SocialDataRepository(RecipesDbContext db) : base(db) { }
    public Task AddAsync(SocialData data, CancellationToken token)
        => Set.AddAsync(data, token).AsTask();
}
