using Application.Contracts.Responses;
using EHR.Application.Wrappers;
using MediatR;

namespace Application.Features.Properties.Queries.GetPaginated
{
    public record GetPaginatedPropertiesQuery(
        int PageNumber,
        int PageSize,
        string? filterByName,
        string? filterByLocation,
        int? filterByStatus,
        int? filterByHostId
) : IRequest<Pagination<PropertyResponse>>;
}