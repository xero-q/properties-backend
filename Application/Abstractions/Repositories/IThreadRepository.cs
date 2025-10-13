using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IThreadRepository:IGenericRepositoryAsync<Booking>
{
    Task<bool> TitleExistsAsync(int userId, string title, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Booking>> GetAllByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default);
    
    Task<int> GetTotalThreadsCount(int userId, CancellationToken cancellationToken = default);
    
    Task<Booking?> GetByIdAsync(int threadId, bool includeJoins = false, CancellationToken cancellationToken = default);
}