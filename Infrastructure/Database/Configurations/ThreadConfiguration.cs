using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ThreadConfiguration:IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("threads");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        
        builder.Property(t => t.Title).HasColumnName("title").IsRequired().HasMaxLength(255);
        
        builder.Property(t => t.CreatedAt).HasColumnName("created_at").IsRequired();
        
        builder.Property(t => t.ModelId).HasColumnName("model_id").IsRequired();
        
        builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
        
        builder.HasOne(t=>t.Host).WithMany(t => t.Threads).HasForeignKey(t=>t.ModelId).IsRequired();
        
        builder.HasOne(t=>t.User).WithMany(u => u.Threads).HasForeignKey(t=>t.UserId).IsRequired();
        
    }
}