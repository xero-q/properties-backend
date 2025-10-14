using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bookings;
using Domain.DomainEvents;
using Domain.Hosts;
using SharedKernel;

namespace Domain.Properties;

public enum PropertyStatus
{
    Inactive = 0,
    Active = 0
}

[Table("Properties")]
public class Property:Entity
{
   
    public int HostId { get; set; }
    
    public Host Host { get; set; } = null!;
    
    public string Name { get; set; }
    
    public string Location { get; set; }

    public decimal PricePerNight { get; set; }
    
    public PropertyStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public List<Booking> Bookings { get; set; } = [];
    
    public List<DomainEvent> DomainEvents { get; set; } = [];
}