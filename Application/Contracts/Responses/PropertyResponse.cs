using Domain.Hosts;
using Domain.Properties;

namespace Application.Contracts.Responses;

public sealed class PropertyResponse
{
    public int Id { get; init; }
    
    public required int HostId { get; init; }
    
    public required HostResponse Host { get; init; } = null!;
    
    public required string Name { get; init; }
    
    public required string Location { get; init; }
    
    public required decimal PricePerNight { get; init; }
    
    public required PropertyStatus Status { get; init; } 
    
    public required DateTime CreatedAt { get; init; }

}