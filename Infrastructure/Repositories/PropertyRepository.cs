using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Mappings;
using Domain.Properties;
using Application.Wrappers;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository(ApplicationDbContext context) : GenericRepositoryAsync<Property>(context), IPropertyRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<Property?> GetByIdWithHostAsync(int id,CancellationToken cancellationToken=default)
    {
        return await context.Properties
            .Include(p => p.Host)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Pagination<PropertyResponse>> GetPaginatedPropertiesAsync(int pageNumber, int pageSize, string? filterByName,string? filterByLocation,int? filterByStatus, int? filterByHostId)
    {
        // Base query
        var query = _context.Properties.AsQueryable();

        // Apply filter by Name if provided
        if (!string.IsNullOrWhiteSpace(filterByName))
        {
            string search = $"%{filterByName.Trim()}%";
            query = query.Where(p =>
                EF.Functions.Like(p.Name, search));
        }
        
        // Apply filter by Location if provided
        if (!string.IsNullOrWhiteSpace(filterByLocation))
        {
            string search = $"%{filterByLocation.Trim()}%";
            query = query.Where(p =>
                EF.Functions.Like(p.Location, search));
        }
        
        // Apply filter by Status if provided
        if (filterByStatus is not null)
        {
            query = query.Where(p => (int)p.Status == filterByStatus);
        }
        
        // Apply filter by HostId if provided
        if (filterByHostId is not null)
        {
            query = query.Where(p => p.HostId == filterByHostId);
        }

        // Calculate total count without materializing the query
        var totalCountQuery = await query.CountAsync();

        // Ensure valid pageNumber
        pageNumber = Math.Max(1, Math.Min(pageNumber, (int)Math.Ceiling((double)totalCountQuery / pageSize)));

        // Calculate skip
        var skip = (pageNumber - 1) * pageSize;

        var results = await query
            .Include(p=>p.Host)
            .OrderBy(c => c.Id)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var mappedResults = results.Select(p => p.MapToResponse()
     ).ToList();

        var totalPages = (int)Math.Ceiling((double)totalCountQuery / pageSize);

        return new Pagination<PropertyResponse>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalPages = totalPages,
            TotalItems = totalCountQuery,
            Result = mappedResults.ToList()
        };
    }
}