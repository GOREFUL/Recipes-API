using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
public class CreateLevelCommandHandler
    (ILogger<CreateLevelCommandHandler> logger, IUnitOfWork uow, ILevelRepository repo)
    : IRequestHandler<CreateLevelCommand, int>
{
    public async Task<int> Handle(CreateLevelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateLevelCommand");
        await uow.BeginAsync(cancellationToken);

        try
        {
            if (await repo.ExistsByNameAsync(request.Dto.Name, cancellationToken))
                throw new InvalidOperationException($"Level with name '{request.Dto.Name}' already exists.");
            
            var entity = new Level { Name = request.Dto.Name.Trim() };
            await repo.AddAsync(entity, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);
            await uow.CommitAsync(cancellationToken);
            return entity.Id;
        }
        catch
        {
            await uow.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
