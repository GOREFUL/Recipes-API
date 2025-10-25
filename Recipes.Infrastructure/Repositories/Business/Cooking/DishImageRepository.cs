using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public class DishImageRepository : EfRepositoryBase<Image>, IDishImageRepository
{
    public DishImageRepository(RecipesDbContext db) : base(db) { }

    public Task AddRangeAsync(IEnumerable<Image> images, CancellationToken token)
        => Set.AddRangeAsync(images, token);
}
