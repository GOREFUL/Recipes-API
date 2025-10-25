using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Cooking.Links;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business.Cooking;
public sealed class DishRepository : EfRepositoryBase<Dish>, IDishRepository
{
    public DishRepository(RecipesDbContext db) : base(db) { }

    public Task AddAsync(Dish dish, CancellationToken token)
        => Set.AddAsync(dish, token).AsTask();

    public Task<Dish?> GetByIdAsync(int id, CancellationToken token)
        => Set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, token);

    public async Task<Dish?> GetByIdWithDetailsAsync(int id, CancellationToken token)
        => await Set.AsNoTracking()
              .Where(x => x.Id == id)
              .Include(x => x.DishInfo)
                  .ThenInclude(i => i.Images)
              .Include(x => x.DishInfo)
                  .ThenInclude(i => i.IngredientUnits)
              .Include(x => x.DishInfo)
                  .ThenInclude(i => i.Allergies)
              .Include(x => x.DishInfo)
                  .ThenInclude(i => i.Cuisines)
              .Include(x => x.DishInfo)
                  .ThenInclude(i => i.Macronutrients)
              .FirstOrDefaultAsync(token);

    public async Task<(IReadOnlyList<Dish> Items, int Total)> GetUserPageAsync(Guid userId, int page, int size, string? name, CancellationToken token)
    {
        var q = Set.AsNoTracking().Where(x => x.CookId == userId);
        if (!string.IsNullOrWhiteSpace(name))
            q = q.Where(x => x.Name.Contains(name));

        var total = await q.CountAsync(token);
        var items = await q.OrderByDescending(x => x.CreatedAt)
                           .Skip((page - 1) * size)
                           .Take(size)
                           .ToListAsync(token);
        return (items, total);
    }

    public async Task<(IReadOnlyList<(Dish Dish, bool IsFavorite)> Items, int Total)> SearchPageAsync(Guid? currentUserId, int page, int size, string? name, CancellationToken token)
    {
        var q = Set.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(name))
            q = q.Where(x => x.Name.Contains(name));

        var total = await q.CountAsync(token);
        var items = await q.OrderByDescending(x => x.CreatedAt)
                           .Skip((page - 1) * size)
                           .Take(size)
                           .ToListAsync(token);

        if (currentUserId is null)
            return (items.Select(d => (d, false)).ToList(), total);

        var ids = items.Select(d => d.Id).ToList();
        var favIds = await Db.FavoriteDishes
            .Where(f => f.UserId == currentUserId && ids.Contains(f.DishId))
            .Select(f => f.DishId)
            .ToListAsync(token);
        var favSet = favIds.ToHashSet();

        return (items.Select(d => (d, favSet.Contains(d.Id))).ToList(), total);
    }

    public async Task DeleteAsync(Dish dish, CancellationToken token)
    {
        Set.Remove(dish);
        await Task.CompletedTask;
    }

    public async Task AddFavoriteAsync(Guid userId, int dishId, CancellationToken token)
    {
        var exists = await Db.FavoriteDishes.AnyAsync(f => f.UserId == userId && f.DishId == dishId, token);
        if (!exists)
        {
            await Db.FavoriteDishes.AddAsync(new Domain.Entities.Business.Cooking.Links.FavoriteDish
            {
                UserId = userId,
                DishId = dishId,
                AddedAtUtc = DateTime.UtcNow
            }, token);
        }
    }

    public async Task RemoveFavoriteAsync(Guid userId, int dishId, CancellationToken token)
    {
        var entity = await Db.FavoriteDishes.FirstOrDefaultAsync(f => f.UserId == userId && f.DishId == dishId, token);
        if (entity is not null) Db.FavoriteDishes.Remove(entity);
    }

    public Task<bool> IsFavoriteAsync(Guid userId, int dishId, CancellationToken token)
        => Db.FavoriteDishes.AnyAsync(f => f.UserId == userId && f.DishId == dishId, token);

    public Task<bool> ExistsByNameForUserAsync(Guid userId, string name, CancellationToken token)
        => Set.AnyAsync(x => x.CookId == userId && x.Name == name, token);

    public async Task<IReadOnlyList<Dish>> GetMyAsync(Guid userId, int page, int pageSize, string? name, CancellationToken token)
    {
        var (items, _) = await GetUserPageAsync(userId, page, pageSize, name, token);
        return items;
    }

    public async Task<IReadOnlyList<(Dish dish, bool isFavorite)>> SearchAsync(Guid? userId, int page, int pageSize, string? name, CancellationToken token)
    {
        var (items, _) = await SearchPageAsync(userId, page, pageSize, name, token);
        return items;
    }
}
