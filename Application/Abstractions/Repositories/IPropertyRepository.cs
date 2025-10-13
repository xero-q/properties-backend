using Application.Contracts.Responses;
using Domain.Entities;
using EHR.Application.Wrappers;

namespace Application.Abstractions.Repositories;

public interface IPropertyRepository:IGenericRepositoryAsync<Property>
{
    public Task<Pagination<PropertyResponse>> GetPaginatedPropertiesAsync(int pageNumber, int pageSize);
}