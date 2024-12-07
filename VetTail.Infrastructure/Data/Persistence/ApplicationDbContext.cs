using Microsoft.EntityFrameworkCore;
using VetTail.Domain.Entities;

namespace VetTail.Infrastructure.Data.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientNotes> ClientNotes { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetNotes> PetNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);  
    }
}
