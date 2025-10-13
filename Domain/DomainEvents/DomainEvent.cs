using SharedKernel;

namespace Domain.Entities;

public enum DomainEventType {

}

public sealed class DomainEvent:Entity
{
    public int PropertyId { get; set; }
    
    public Property Property { get; set; } = null!;
    
    public DomainEventType EventType { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string PayloadJSON { get; set; }
    
  
}