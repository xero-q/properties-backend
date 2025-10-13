using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ThreadRepository(ApplicationDbContext context):GenericRepositoryAsync<Booking>(context),IThreadRepository
{
    public async Task<bool> TitleExistsAsync(int userId, string title, CancellationToken cancellationToken = default)
    {
        return await context.Threads.AnyAsync(t => t.UserId == userId && t.Title == title, cancellationToken);

    }

    public async Task<IEnumerable<Booking>> GetAllByUserIdAsync(int userId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        return await context.Threads
            .Include(t => t.Host)
            .ThenInclude(m => m.Provider)
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetTotalThreadsCount(int userId, CancellationToken cancellationToken = default)
    {
        var query = context.Threads
            .Where(t => t.UserId == userId)
            .AsNoTracking();

        return await query.CountAsync(cancellationToken);
    }

    public async Task<Booking?> GetByIdAsync(int threadId, bool includeJoins = false, CancellationToken cancellationToken = default)
    {
        if (includeJoins)
        {
            return  await context.Threads.Include(t => t.Host).ThenInclude(m => m.Provider).FirstOrDefaultAsync(t => t.Id == threadId, cancellationToken);
        }

        return await context.Threads.FindAsync(threadId,cancellationToken);
    }
}