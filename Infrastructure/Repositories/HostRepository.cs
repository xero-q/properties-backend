using Application.Abstractions.Repositories;
using Domain.Hosts;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Repositories;

public class HostRepository(ApplicationDbContext context) : GenericRepositoryAsync<Host>(context), IHostRepository
{
    
}