using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IStepRepository
{
    Task AddRangeAsync(IEnumerable<Step> steps, CancellationToken token);
}
