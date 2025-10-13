using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class UserConfiguration:IEntityTypeConfiguration<DomainEvent>
{
    public void Configure(EntityTypeBuilder<DomainEvent> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(u=>u.Id);
        builder.Property(u => u.Id).HasColumnName("id");
        
        builder.Property(u => u.Username).HasColumnName("username").IsRequired().HasMaxLength(255);
        builder.Property(u => u.Password).HasColumnName("password").IsRequired();
        
        builder.Property(u=>u.IsAdmin).HasColumnName("is_admin").IsRequired();
        
        builder.HasIndex(u=>u.Username).IsUnique();
    }
}