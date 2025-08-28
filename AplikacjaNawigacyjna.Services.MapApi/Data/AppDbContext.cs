using AplikacjaNawigacyjna.Services.MapApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.MapApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MapPoint> MapPoints { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
