using Application.Contracts.Responses;
using Domain.Properties;
using Application.Wrappers;

namespace Application.Abstractions.Repositories;

public interface IPropertyRepository:IGenericRepositoryAsync<Property>
{
    public Task<Pagination<PropertyResponse>> GetPaginatedPropertiesAsync(int pageNumber, int pageSize, string? filterByName,string? filterByLocation,int? filterByStatus, int? filterByHostId);
}