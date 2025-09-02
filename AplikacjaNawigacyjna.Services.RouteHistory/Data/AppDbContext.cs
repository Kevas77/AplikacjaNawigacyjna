using AplikacjaNawigacyjna.Services.RouteHistory.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.RouteHistory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<RouteRecord> RoutesHistory { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
