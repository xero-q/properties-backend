using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ModelRepository(ApplicationDbContext context) : GenericRepositoryAsync<Host>(context), IModelRepository
{
    public override async Task<IEnumerable<Host>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Models.Include(m=>m.Provider).AsNoTracking().ToListAsync(cancellationToken);
    }

    public override async Task<Host?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Models.Include(m=>m.Provider).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);;
    }
}