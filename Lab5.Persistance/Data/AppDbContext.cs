using Microsoft.EntityFrameworkCore;

namespace Lab5.Persistence.Data;

public class AppDbContext : DbContext
{
    public DbSet<Singer> Singers { get; set; }

    public DbSet<Song> Songs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
