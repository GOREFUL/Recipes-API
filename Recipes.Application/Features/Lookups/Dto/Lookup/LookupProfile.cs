using AutoMapper;
using Recipes.Domain.Entities.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Dto.Lookup;
public class LookupProfile : Profile
{
    public LookupProfile()
    {
        CreateMap<Level, LookupItemDto>();
        CreateMap<Ingredient, LookupItemDto>();
        CreateMap<MeasurementUnit, LookupItemDto>();
        CreateMap<Allergy, LookupItemDto>();
        CreateMap<Cuisine, LookupItemDto>();
    }
}