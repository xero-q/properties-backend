using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IUserRepository:IGenericRepositoryAsync<DomainEvent>
{
  Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);

  Task<DomainEvent?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
}