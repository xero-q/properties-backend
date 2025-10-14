using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Mappings;
using Domain.Properties;
using EHR.Application.Wrappers;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository(ApplicationDbContext context) : GenericRepositoryAsync<Property>(context), IPropertyRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pagination<PropertyResponse>> GetPaginatedPropertiesAsync(int pageNumber, int pageSize, string? search)
    {
        // Base query
        var query = _context.Properties.AsQueryable();

        // Apply search filter if provided
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = $"%{search.Trim()}%";
            query = query.Where(p =>
                EF.Functions.Like(p.Name, search) ||
                EF.Functions.Like(p.Location, search));
        }
        
        // Calculate total count without materializing the query
        var totalCountQuery = await query.CountAsync();

        // Ensure valid pageNumber
        pageNumber = Math.Max(1, Math.Min(pageNumber, (int)Math.Ceiling((double)totalCountQuery / pageSize)));

        // Calculate skip
        var skip = (pageNumber - 1) * pageSize;

        var results = await query
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