namespace Recipes.Application.Dish.Dtos;
// Example profile
using AutoMapper;
using Recipes.Application.DishInfo.Dtos;
using Recipes.Application.Images.Dtos;
using Recipes.Application.IngredientUnit.Dtos;
using Recipes.Application.Macronutrients.Dtos;
using Recipes.Application.Users.Dtos;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Cooking.Advanced;
using Recipes.Domain.Entities.UserContext;

public class DishMappingProfile : Profile
{
    public DishMappingProfile()
    {
        // Root
        CreateMap<CreateDishDto, Dish>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.CookId, m => m.Ignore())   // виставляємо у Handler
            .ForMember(d => d.CreatedAt, m => m.Ignore());  // виставляємо у Handler

        // One-to-one
        CreateMap<CreateDishInfoDto, DishInfo>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DishId, m => m.Ignore())       // у Handler
            .ForMember(d => d.Note, m => m.MapFrom(s => s.Note ?? string.Empty));

        CreateMap<CreateMacronutrientsDto, Macronutrients>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DishInfoId, m => m.Ignore());

        // Children
        CreateMap<CreateIngredientUnitDto, IngredientUnit>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DishInfoId, m => m.Ignore())
            .ForMember(d => d.MeasurementUnitId, m => m.MapFrom(s => s.MeasurementUnitId));


        // Images: DTO -> Entity (а не string -> Image)
        CreateMap<CreateImageDto, Image>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DishInfoId, m => m.Ignore())
            .ForMember(d => d.Url, m => m.MapFrom(s => s.Url.Trim()));
    }
}
