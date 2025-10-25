using AutoMapper;
using IngredientUnits = Recipes.Domain.Entities.Business.Cooking.IngredientUnit;

namespace Recipes.Application.IngredientUnit.Dtos;
public class IngredientUnitProfile : Profile
{
    public IngredientUnitProfile()
    {
        CreateMap<CreateIngredientUnitDto, IngredientUnits>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DishInfoId, m => m.Ignore())
            .ForMember(d => d.IngredientId, m => m.MapFrom(s => s.IngredientId))
            .ForMember(d => d.MeasurementUnitId, m => m.MapFrom(s => s.MeasurementUnitId)) // ← ВАЖЛИВО: MeasureUnitId → MeasurementUnitId
            .ForMember(d => d.Value, m => m.MapFrom(s => s.Value));

    }
}
