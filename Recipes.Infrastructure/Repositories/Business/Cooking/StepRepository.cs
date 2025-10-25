using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public class StepRepository : EfRepositoryBase<Step>, IStepRepository
{
    public StepRepository(RecipesDbContext db) : base(db) { }
    public Task AddRangeAsync(IEnumerable<Step> steps, CancellationToken token) 
        => Set.AddRangeAsync(steps, token);
}
