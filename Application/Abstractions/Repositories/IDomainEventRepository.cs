using Domain.DomainEvents;

namespace Application.Abstractions.Repositories;

public interface IDomainEventRepository:IGenericRepositoryAsync<DomainEvent>
{
}