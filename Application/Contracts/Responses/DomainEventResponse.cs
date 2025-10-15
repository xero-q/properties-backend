using Domain.Hosts;
using Domain.Properties;

namespace Application.Contracts.Responses;

public sealed class DomainEventResponse
{
    public int Id { get; init; }
    
    public required int PropertyId { get; init; }
  
    public required string EventType { get; init; }
    
    public required DateTime CreatedAt { get; set; }
    
    public required string PayloadJSON { get; set; }

}