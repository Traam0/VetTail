using System.Reflection;
using VetTail.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VetTail.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
