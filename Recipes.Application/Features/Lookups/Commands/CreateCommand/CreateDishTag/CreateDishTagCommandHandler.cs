using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateAllergy;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateDishTag;
public class CreateDishTagCommandHandler
    (ILogger<CreateLevelCommandHandler> logger, IUnitOfWork uow, IDishTagRepository repo)
    : IRequestHandler<CreateAllergyCommand, int>
{
    public async Task<int> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateDishTagCommand");
        await uow.BeginAsync(cancellationToken);
        try
        {
            if(await repo.ExistsByNameAsync(request.Dto.Name, cancellationToken))
                throw new InvalidOperationException($"DishTag with name '{request.Dto.Name}' already exists.");
        
            var entity = new DishTag { Name = request.Dto.Name.Trim() };
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
