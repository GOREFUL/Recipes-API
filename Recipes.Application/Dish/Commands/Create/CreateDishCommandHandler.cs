using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking.Advanced;
using Recipes.Domain.Repositories.Business.Enumerations;
using Recipes.Domain.Repositories.Read;
using Recipes.Domain.Repositories.System;
using DishInfos = Recipes.Domain.Entities.Business.Cooking.DishInfo;
using Dishs = Recipes.Domain.Entities.Business.Cooking.Dish;
using Imagess = Recipes.Domain.Entities.Business.Cooking.Image;
using IngredientUnitss = Recipes.Domain.Entities.Business.Cooking.IngredientUnit;
using Macronutrientss = Recipes.Domain.Entities.Business.Cooking.Advanced.Macronutrients;

namespace Recipes.Application.Dish.Commands.Create;

public class CreateDishCommandHandler
    (ILogger<CreateDishCommandHandler> logger, IUnitOfWork uow, IDishRepository dishes,
     IDishInfoRepository infos, IDishImageRepository images, IIngredientUnitRepository units, IMacronutrientsRepository macros,
     IAllergyRepository allergies, ICuisineRepository cuisines, IMapper mapper, IMeasureUnitReadRepository measureUnitReadRepo,
     IIngredientReadRepository ingredientReadRepo, ILevelReadRepository levelReadRepo, ICurrentUser currentUser)
    : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken ct)
    {
        logger.LogInformation("Creating a new dish…");

        if (currentUser.UserId == Guid.Empty)
        {
            logger.LogWarning("Unauthorized user attempted to create a dish");
            throw new UnauthorizedAccessException("User must be authenticated to create a dish.");
        }

        await uow.BeginAsync(ct);

        try
        {
            // 1) Dish
            var dish = mapper.Map<Dishs>(request.Dto);
            dish.CreatedAt = DateTime.UtcNow;
            dish.CookId = currentUser.UserId!.Value;

            await dishes.AddAsync(dish, ct);
            await uow.SaveChangesAsync(ct);

            // 2) DishInfo
            var infoDto = request.Dto.Info;
            if (infoDto.LevelId <= 0 || !await levelReadRepo.ExistsAsync(infoDto.LevelId, ct))
                throw new InvalidOperationException($"LevelId {infoDto.LevelId} does not exist.");

            var info = mapper.Map<DishInfos>(request.Dto.Info);
            info.DishId = dish.Id;

            await infos.AddAsync(info, ct);
            await uow.SaveChangesAsync(ct);

            // 3) 1-1 Macronutrients
            if (request.Dto.Info.Macros is not null)
            {
                var macro = mapper.Map<Macronutrientss>(request.Dto.Info.Macros);
                macro.DishInfoId = info.Id;
                await macros.AddAsync(macro, ct);
            }

            // 4) IngredientUnits
            if (request.Dto.Ingredients?.Any() == true)
            {
                var mapped = mapper.Map<List<IngredientUnitss>>(request.Dto.Ingredients);
                foreach (var u in mapped) u.DishInfoId = info.Id;

                var muIds = mapped.Select(u => u.MeasurementUnitId).Where(id => id > 0).Distinct().ToArray();
                var ingIds = mapped.Select(u => u.IngredientId).Where(id => id > 0).Distinct().ToArray();

                var existingMu = await measureUnitReadRepo.GetExistingIdsAsync(muIds, ct);
                var existingIng = await ingredientReadRepo.GetExistingIdsAsync(ingIds, ct);

                var missingMu = muIds.Except(existingMu).ToArray();
                var missingIng = ingIds.Except(existingIng).ToArray();

                if (missingMu.Length > 0 || missingIng.Length > 0)
                    throw new InvalidOperationException(
                        $"Missing ids: MeasurementUnitId[{string.Join(',', missingMu)}], IngredientId[{string.Join(',', missingIng)}]");

                await units.AddRangeAsync(mapped, ct);
            }

            // 5) Images (URL)
            if (request.Dto.ImageUrls?.Any() == true)
            {
                var imgs = mapper.Map<List<Imagess>>(request.Dto.ImageUrls);
                foreach (var i in imgs) i.DishInfoId = info.Id;
                await images.AddRangeAsync(imgs, ct);
            }

            // 6) M2M
            if (request.Dto.AllergyIds?.Any() == true)
            {
                var ent = await allergies.GetByIdsAsync(request.Dto.AllergyIds, ct);
                await infos.AddAllergiesAsync(info.Id, ent, ct);
            }
            if (request.Dto.CuisineIds?.Any() == true)
            {
                var ent = await cuisines.GetByIdsAsync(request.Dto.CuisineIds, ct);
                await infos.AddCuisinesAsync(info.Id, ent, ct);
            }

            await uow.SaveChangesAsync(ct);
            await uow.CommitAsync(ct);

            logger.LogInformation("Dish {DishId} created", dish.Id);
            return dish.Id;
        }
        catch (Exception ex)
        {
            await uow.RollbackAsync(ct);
            logger.LogError(ex, "Error occurred while creating a new dish");
            throw;
        }
    }
}
