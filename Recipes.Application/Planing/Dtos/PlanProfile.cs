using AutoMapper;
using Recipes.Domain.Entities.Business.Cooking;

namespace Recipes.Application.Planing.Dtos;
public class PlanProfile : Profile
{
    public PlanProfile()
    {
        CreateMap<Plan, PlanDto>()
            .ForCtorParam(nameof(PlanDto.DishName), opt => opt.MapFrom(p => p.Dish.Name));

        CreateMap<Plan, PlanListItemDto>()
            .ForCtorParam(nameof(PlanListItemDto.DishName), opt => opt.MapFrom(p => p.Dish.Name));

        CreateMap<CreatePlanDto, Plan>();
        CreateMap<UpdatePlanDto, Plan>();
    }
}
