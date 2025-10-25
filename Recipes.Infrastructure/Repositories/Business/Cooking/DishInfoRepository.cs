using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public class DishInfoRepository : EfRepositoryBase<DishInfo>, IDishInfoRepository
{
    public DishInfoRepository(RecipesDbContext db) : base(db) { }
    public Task AddAsync(DishInfo info, CancellationToken token)
         => Set.AddAsync(info, token).AsTask();

    public Task<DishInfo?> GetDishByIdAsync(int dishId, CancellationToken token)
        => Set.FirstOrDefaultAsync(x => x.DishId == dishId, token);

    public async Task AddAllergiesAsync(int dishInfoId, IReadOnlyCollection<Allergy> allergies, CancellationToken token)
    {
        var info = await Set.Include(x => x.Allergies).FirstAsync(x => x.Id == dishInfoId, token);
        foreach (var allergy in allergies)
        {
            info.Allergies.Add(allergy);
        }
    }

    public async Task AddCuisinesAsync(int dishInfoId, IReadOnlyCollection<Cuisine> cuisines, CancellationToken token)
    {
        var info = await Set.Include(x => x.Cuisines).FirstAsync(x => x.Id == dishInfoId, token);
        foreach (var cuisine in cuisines)
        {
            info.Cuisines.Add(cuisine);
        }
    }
}
