using MediatR;
using Recipes.Application.Features.Lookups.Dto.Lookup;

namespace Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetCuisinePage;
public record GetCuisinePageQuery(string? Q, int Page = 1, int PageSize = 20)
    : IRequest<Paged<LookupItemDto>>;
