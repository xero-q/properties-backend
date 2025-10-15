namespace Application.Contracts.Requests;

public sealed class CreateDomainEventRequest
{
    public required int PropertyId { get; init; }
    
    public required string EventType { get; init; }
    
    public required string PayloadJSON { get; init; }

}