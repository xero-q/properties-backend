using Domain.Entities;

namespace Application.Contracts.Responses;

public sealed class PropertyResponse
{
    public int Id { get; init; }
    
    public int HostId { get; init; }
    
    public required string Name { get; init; }
    
    public required string Location { get; init; }
    
    public required double PricePerNight { get; init; }
    
    public required PropertyStatus Status { get; init; } 

}