using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Recipes.Application.Features.Lookups.Dto.Lookup;
using Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetAllergyPage;
using Recipes.Domain.Repositories.Business.Enumerations;

namespace Recipes.Application.Features.Lookups.Queries.GetLookupPage.GetCuisinePage;
public class GetCuisinePageQueryHandler
    (ILogger<GetCuisinePageQueryHandler> logger, ICuisineRepository repo, IMapper mapper)
    : IRequestHandler<GetCuisinePageQuery, Paged<LookupItemDto>>
{
    public async Task<Paged<LookupItemDto>> Handle(GetCuisinePageQuery r, CancellationToken ct)
    {
        logger.LogInformation("Getting cuisines page {Page} with page size {PageSize} " +
            "and search query {Q}", r.Page, r.PageSize, r.Q ?? "null");
        var (items, total) = await repo.GetPageAsync(r.Q, r.Page, r.PageSize, ct);
        return new Paged<LookupItemDto>(mapper
            .Map<IReadOnlyList<LookupItemDto>>(items), total, r.Page, r.PageSize);
    }
}
