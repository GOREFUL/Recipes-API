using Recipes.Domain.Entities.Business.Cooking.Advanced;
using Recipes.Domain.Repositories.Business.Cooking.Advanced;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking.Advanced;
public class MicronutrientsRepository : EfRepositoryBase<Micronutrients>, IMicronutrientsRepository
{
    public MicronutrientsRepository(RecipesDbContext db) : base(db) { }
    public Task AddAsync(Micronutrients micro, CancellationToken token) 
        => Set.AddAsync(micro, token).AsTask();
}