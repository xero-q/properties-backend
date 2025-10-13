using Application.Abstractions.Repositories;
using Application.Contracts.Responses;
using Application.Mappings;
using Domain.Entities;
using EHR.Application.Wrappers;
using Infrastructure.Database.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PropertyRepository(ApplicationDbContext context) : GenericRepositoryAsync<Property>(context), IPropertyRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pagination<PropertyResponse>> GetPaginatedPropertiesAsync(int pageNumber, int pageSize)
    {
        // Calculate total count without materializing the query
        var totalCountQuery = await _context.Hosts.CountAsync();

        // Ensure valid pageNumber
        pageNumber = Math.Max(1, Math.Min(pageNumber, (int)Math.Ceiling((double)totalCountQuery / pageSize)));

        // Calculate skip
        var skip = (pageNumber - 1) * pageSize;

        var results = await _context.Properties
            .OrderByDescending(c => c.Id)
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