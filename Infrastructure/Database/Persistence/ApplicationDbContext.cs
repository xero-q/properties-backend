using Application.Abstractions.Data;
using Domain.Bookings;
using Domain.DomainEvents;
using Domain.Hosts;
using Domain.Properties;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options),IApplicationDbContext
{
    public DbSet<Host> Hosts { get; set; }
    public DbSet<Booking> Bookins { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<DomainEvent> DomainEvents { get; set; }
}