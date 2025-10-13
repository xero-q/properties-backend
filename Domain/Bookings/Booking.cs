using Domain.Properties;
using SharedKernel;

namespace Domain.Bookings;

public class Booking:Entity
{
    public int PropertyId { get; set; }
    
    public Property Property { get; set; } = null!;
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }
    
    public double TotalPrice { get; set; }
}