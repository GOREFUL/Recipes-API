using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking;
using Recipes.Domain.Repositories.Business.Cooking.Advanced;
using Recipes.Domain.Repositories.Business.Enumerations;
using DishInfos = Recipes.Domain.Entities.Business.Cooking.DishInfo;
using Dishs = Recipes.Domain.Entities.Business.Cooking.Dish;
using IngredientUnitss = Recipes.Domain.Entities.Business.Cooking.IngredientUnit;
using Macronutrientss = Recipes.Domain.Entities.Business.Cooking.Advanced.Macronutrients;
using Micronutrientss = Recipes.Domain.Entities.Business.Cooking.Advanced.Micronutrients;
using Imagess = Recipes.Domain.Entities.Business.Cooking.Image;

namespace Recipes.Application.Dish.Commands.Create;
public class CreateDishCommandHandler
    (ILogger<CreateDishCommandHandler> logger, IUnitOfWork uow, IDishRepository dishes, IDishInfoRepository infos,
    IDishImageRepository images, IIngredientUnitRepository units, IMacronutrientsRepository macros,
    IMicronutrientsRepository micros, IAllergyRepository allergies, ICuisineRepository cuisines, IDishTagRepository tags,
    IMapper mapper) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new dish");
        await uow.BeginAsync(cancellationToken);

        try
        {
            // dish
            var dish = mapper.Map<Dishs>(request.Dto);
            await dishes.AddAsync(dish, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);

            // dishinfo
            var info = mapper.Map<DishInfos>(request.Dto.Info);
            info.DishId = dish.Id;
            await infos.AddAsync(info, cancellationToken);
            await uow.SaveChangesAsync(cancellationToken);

            // 1-1 nutrients
            if (request.Dto.Info.Macros is null)
            {
                var macro = mapper.Map<Macronutrientss>(request.Dto.Info.Macros);
                macro.DishInfoId = info.Id;
                await macros.AddAsync(macro, cancellationToken);
            }
            if (request.Dto.Info.Micros is null)
            {
                var micro = mapper.Map<Micronutrientss>(request.Dto.Info.Micros);
                micro.DishInfoId = info.Id;
                await micros.AddAsync(micro, cancellationToken);
            }

            // ingredient units
            if (request.Dto.Ingredients.Count > 0)
            {
                var _units = mapper.Map<List<IngredientUnitss>>(request.Dto.Ingredients);
                foreach (var u in _units) u.DishInfoId = info.Id;
                await units.AddRangeAsync(_units, cancellationToken);
            }

            // images
            if (request.Dto.ImageUrls.Count > 0)
            {
                var imgs = mapper.Map<List<Imagess>>(request.Dto.ImageUrls);
                foreach (var i in imgs) i.DishInfoId = info.Id;
                await images.AddRangeAsync(imgs, cancellationToken);
            }

            // m2m
            if (request.Dto.AllergyIds.Count > 0)
            {
                var ent = await allergies.GetByIdsAsync(request.Dto.AllergyIds, cancellationToken);
                await infos.AddAllergiesAsync(info.Id, ent, cancellationToken);
            }
            if (request.Dto.CuisineIds.Count > 0)
            {
                var ent = await cuisines.GetByIdsAsync(request.Dto.CuisineIds, cancellationToken);
                await infos.AddCuisinesAsync(info.Id, ent, cancellationToken);
            }
            if (request.Dto.TagIds.Count > 0)
            {
                var ent = await tags.GetByIdsAsync(request.Dto.TagIds, cancellationToken);
                await infos.AddTagsAsync(info.Id, ent, cancellationToken);
            }

            await uow.SaveChangesAsync(cancellationToken);
            await uow.CommitAsync(cancellationToken);
            return dish.Id;
        }
        catch
        {
            await uow.RollbackAsync(cancellationToken);
            logger.LogError("Error occurred while creating a new dish");
            throw;
        }
    }
}
