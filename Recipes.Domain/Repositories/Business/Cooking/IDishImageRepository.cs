using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IDishImageRepository
{
    Task AddRangeAsync(IEnumerable<Image> images, CancellationToken token);
}
