using Recipes.Domain.Entities.Business.Social;

namespace Recipes.Domain.Repositories.Business.Social;

public interface IPostRepository
{
    Task AddAsync(Post post, CancellationToken token);
    Task<Post?> GetByIdAsync(int id, CancellationToken token);
    Task<bool> DishExistsAsync(int dishId, CancellationToken token);
}
