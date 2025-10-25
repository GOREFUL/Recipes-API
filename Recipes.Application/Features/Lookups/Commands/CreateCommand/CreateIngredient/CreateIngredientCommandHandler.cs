using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateIngredient;
public class CreateIngredientHandler
    (ILogger<CreateLevelCommandHandler> logger, IUnitOfWork uow, IIngredientRepository repo)
    : IRequestHandler<CreateIngredientCommand, int>
{
    public async Task<int> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateIngredientCommand");
        await uow.BeginAsync(cancellationToken);

        try
        {
            if(await repo.ExistsByNameAsync(request.dto.Name, cancellationToken))
                throw new InvalidOperationException($"Ingredient with name '{request.dto.Name}' already exists.");
        
            var entity = new Ingredient { Name = request.dto.Name.Trim() };
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
