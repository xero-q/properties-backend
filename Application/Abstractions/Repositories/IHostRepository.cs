using Application.Contracts.Responses;
using Domain.Entities;
using EHR.Application.Wrappers;

namespace Application.Abstractions.Repositories;

public interface IHostRepository:IGenericRepositoryAsync<Host>
{
}