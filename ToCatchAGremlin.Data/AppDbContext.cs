
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<JailHouse> Jails { get; set; }
    public DbSet<Gremlin> Gremlins { get; set; }
    public DbSet<Charge> Charges { get; set; }
}
