using Microsoft.EntityFrameworkCore;
using mySystem.Domain.Entities;

namespace mySystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    // Constructor:
    public AppDbContext(DbContextOptions<AppDbContext> options)
    :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // user restrictions:
        var user = modelBuilder.Entity<User>();
        user.HasIndex(u => u.Email)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    
    // Tables:
    public DbSet<User> Users { get; set; }
    public DbSet<Photo> Photos { get; set; }
}