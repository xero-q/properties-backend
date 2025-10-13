using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Repositories;

public class HostRepository(ApplicationDbContext context) : GenericRepositoryAsync<Host>(context), IHostRepository
{
    
}