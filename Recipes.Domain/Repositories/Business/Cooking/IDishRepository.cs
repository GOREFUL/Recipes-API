using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IDishRepository
{
    Task AddAsync(Dish dish, CancellationToken token);
    Task<Dish?> GetByIdAsync(int id, CancellationToken token);
    Task<Dish?> GetByIdWithDetailsAsync(int id, CancellationToken token);
    Task<(IReadOnlyList<Dish> Items, int Total)> GetUserPageAsync(Guid userId, int page, int size, string? name, CancellationToken token);
    Task<(IReadOnlyList<(Dish Dish, bool IsFavorite)> Items, int Total)> SearchPageAsync(Guid? currentUserId, int page, int size, string? name, CancellationToken token);
    Task DeleteAsync(Dish dish, CancellationToken token);
    Task AddFavoriteAsync(Guid userId, int dishId, CancellationToken token);
    Task RemoveFavoriteAsync(Guid userId, int dishId, CancellationToken token);
    Task<bool> IsFavoriteAsync(Guid userId, int dishId, CancellationToken token);
    Task<bool> ExistsByNameForUserAsync(Guid userId, string name, CancellationToken token);
    Task<IReadOnlyList<Dish>> GetMyAsync(Guid userId, int page, int pageSize, string? name, CancellationToken token);
    Task<IReadOnlyList<(Dish dish, bool isFavorite)>> SearchAsync(Guid? userId, int page, int pageSize, string? name,
        CancellationToken token);
}
