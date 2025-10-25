using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Domain.Repositories.Business.Cooking;

public interface IPlanRepository
{
    Task AddAsync(Plan plan, CancellationToken token);
    Task UpdateAsync(Plan plan, CancellationToken token);
    Task DeleteAsync(Plan plan, CancellationToken token);

    Task<Plan?> GetByIdAsync(long id, Guid userId, CancellationToken token);
    Task<Plan?> GetByIdWithDishAsync(long id, Guid userId, CancellationToken token);

    Task<IReadOnlyList<Plan>> GetRangeAsync(Guid userId, DateOnly from, DateOnly to, CancellationToken token);
    Task<IReadOnlyList<Plan>> GetByMonthAsync(Guid userId, int year, int month, CancellationToken token);

    Task<bool> ExistsSlotAsync(Guid userId, DateOnly date, TimeSpan time, CancellationToken token);
}
