using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IDishInfoRepository
{
    Task AddAsync(DishInfo info, CancellationToken token);
    Task<DishInfo?> GetDishByIdAsync(int id, CancellationToken token);

    // m2m
    Task AddAllergiesAsync(int dishInfoId, IReadOnlyCollection<Allergy> allergies, CancellationToken token);
    Task AddCuisinesAsync(int dishInfoId, IReadOnlyCollection<Cuisine> cuisines, CancellationToken token);
    Task AddTagsAsync(int dishInfoId, IReadOnlyCollection<DishTag> tags, CancellationToken token);
}
