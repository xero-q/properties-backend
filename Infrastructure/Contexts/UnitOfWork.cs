using Application.Abstractions.Data;
using Infrastructure.Database.Persistence;

namespace Infrastructure.Contexts
{
    public class UnitOfWork(ApplicationDbContext applicationDbContext) : IUnitOfWork
    {
        public void Dispose() => applicationDbContext.Dispose();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
