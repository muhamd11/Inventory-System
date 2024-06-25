using InvetorySystem.Core.Models.UnitModule;
using Microsoft.EntityFrameworkCore;


namespace InventorySystem.EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Unit> Units { get; set; }
    }
}
