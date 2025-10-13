using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Domain.Entities;

public class Booking:Entity
{
    public int PropertyId { get; set; }
    
    public Property Property { get; set; } = null!;
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }
    
    public double TotalPrice { get; set; }
}