using AplikacjaNawigacyjna.Services.LocalizationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
    }
}
