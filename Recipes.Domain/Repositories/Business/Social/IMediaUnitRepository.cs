using Recipes.Domain.Entities.Business.Social;

namespace Recipes.Domain.Repositories.Business.Social;

public interface IMediaUnitRepository
{
    Task AddAsync(MediaUnit media, CancellationToken token);
}
