using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Infrastructure.Persistance;

namespace Recipes.Infrastructure.Repositories.Business;
public class PlanRepository : EfRepositoryBase<Plan>, IPlanRepository
{
    public PlanRepository(RecipesDbContext db) : base(db) { }

    public Task AddAsync(Plan plan, CancellationToken token)
        => Set.AddAsync(plan, token).AsTask();

    public Task UpdateAsync(Plan plan, CancellationToken token)
    {
        Set.Update(plan);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Plan plan, CancellationToken token)
    {
        Set.Remove(plan);
        return Task.CompletedTask;
    }

    public Task<Plan?> GetByIdAsync(long id, Guid userId, CancellationToken token)
        => Set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId, token);

    public Task<Plan?> GetByIdWithDishAsync(long id, Guid userId, CancellationToken token)
        => Set.AsNoTracking()
            .Include(x => x.Dish)
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId, token);

    public async Task<IReadOnlyList<Plan>> GetRangeAsync(Guid userId, DateOnly from, DateOnly to, CancellationToken token)
        => await Set.AsNoTracking()
            .Where(x => x.UserId == userId && x.Date >= from && x.Date <= to)
            .Include(x => x.Dish)
            .OrderBy(x => x.Date).ThenBy(x => x.TimePoint)
            .ToListAsync(token);

    public async Task<IReadOnlyList<Plan>> GetByMonthAsync(Guid userId, int year, int month, CancellationToken token)
    {
        var start = new DateOnly(year, month, 1);
        var end = start.AddMonths(1).AddDays(-1);
        return await GetRangeAsync(userId, start, end, token);
    }

    public Task<bool> ExistsSlotAsync(Guid userId, DateOnly date, TimeSpan time, CancellationToken token)
        => Set.AsNoTracking().AnyAsync(x => x.UserId == userId && x.Date == date && x.TimePoint == time, token);
}