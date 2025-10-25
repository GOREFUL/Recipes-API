using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public class DishRepository : EfRepositoryBase<Dish>, IDishRepository
{
    public DishRepository(RecipesDbContext db) : base(db) { }
    public Task AddAsync(Dish dish, CancellationToken token)
        => Set.AddAsync(dish, token).AsTask();

    public Task<Dish?> GetByIdAsync(int id, CancellationToken token)
        => Set.FirstOrDefaultAsync(x => x.Id == id, token);
}
