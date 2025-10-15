using Domain.Properties;
using SharedKernel;

namespace Domain.DomainEvents;

public sealed class DomainEvent:Entity
{
    public int PropertyId { get; set; }
    
    public Property Property { get; set; } = null!;
    
    public string EventType { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string PayloadJSON { get; set; }
    
  
}