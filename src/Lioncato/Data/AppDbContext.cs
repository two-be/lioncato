#nullable disable

using Microsoft.EntityFrameworkCore;

namespace Lioncato.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<LocationInfo> Locations { get; set; }
    public DbSet<UserInfo> Users { get; set; }
}