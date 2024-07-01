using Microsoft.EntityFrameworkCore;

namespace Gabfest.Data;

public class GabfestDbContext : DbContext
{
    public GabfestDbContext(DbContextOptions<GabfestDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }

}
