using Recipes.Domain.Entities.Business.Social;

namespace Recipes.Domain.Repositories.Business.Social;

public interface ISocialDataRepository
{
    Task AddAsync(SocialData data, CancellationToken token);
    Task<SocialData?> GetByPostIdAsync(int postId, CancellationToken token);
    Task UpdateAsync(SocialData data, CancellationToken token);
}
