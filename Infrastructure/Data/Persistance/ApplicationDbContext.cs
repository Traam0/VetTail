using Microsoft.EntityFrameworkCore;
using VetTail.Domain.Entities;

namespace VetTail.Infrastructure.Data.Persistance;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
