using Domain.Bookings;
using Domain.DomainEvents;
using Domain.Hosts;
using Domain.Properties;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    public DbSet<Host> Hosts { get; set; }
    public DbSet<Booking> Bookins { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<DomainEvent> DomainEvents { get; set; }
    
    public DbSet<User> Users { get; set; }
}
