using EHR.Application.Wrappers;
using MediatR;
using Application.Abstractions.Repositories;
using Application.Contracts.Responses;

namespace Application.Features.Properties.Queries.GetPaginated
{
    public class GetPaginatedPropertiesQueryHandler(IPropertyRepository propertyRepository) : IRequestHandler<GetPaginatedPropertiesQuery, Pagination<PropertyResponse>>
    {
        public async Task<Pagination<PropertyResponse>> Handle(GetPaginatedPropertiesQuery request, CancellationToken cancellationToken)
        {
            return await propertyRepository.GetPaginatedPropertiesAsync(
                 request.PageNumber,request.PageSize, request.filterByName,request.filterByLocation,request.filterByStatus,request.filterByHostId);
        }
    }
}