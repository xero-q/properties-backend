using Application.Abstractions.Repositories;
using Domain.DomainEvents;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Repositories;

public class DomainEventRepository(ApplicationDbContext context) : GenericRepositoryAsync<DomainEvent>(context), IDomainEventRepository
{
    
}