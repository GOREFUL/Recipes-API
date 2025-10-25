using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateIngredient;
using Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateLevel;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Commands.CreateCommand.CreateAllergy;
public class CreateAllergyCommandHandler
    (ILogger<CreateLevelCommandHandler> logger, IUnitOfWork uow, IAllergyRepository repo)
    : IRequestHandler<CreateAllergyCommand, int>
{
    public async Task<int> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateAllergyCommand");
        await uow.BeginAsync(cancellationToken);
        try
        {
            if(await repo.ExistsByNameAsync(request.Dto.Name, cancellationToken))
                throw new InvalidOperationException($"Allergy with name '{request.Dto.Name}' already exists.");
        
            var entity = new Allergy { Name = request.Dto.Name.Trim() };
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
