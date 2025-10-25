using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateMeasureUnit;
public class CreateMeasureUnitHandler
    (ILogger<CreateLevelCommandHandler> logger, IUnitOfWork uow, IMeasureUnitRepository repo)
    : IRequestHandler<CreateMeasureUnitCommand, int>
{
    public async Task<int> Handle(CreateMeasureUnitCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateMeasureUnitCommand");
        await uow.BeginAsync(cancellationToken);
        try
        {
            if (await repo.ExistsByNameAsync(request.dto.Name, cancellationToken))
                throw new InvalidOperationException($"MeasureUnit with name '{request.dto.Name}' already exists.");
            var entity = new MeasurementUnit { Name = request.dto.Name.Trim() };
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
