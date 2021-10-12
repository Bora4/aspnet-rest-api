using Microsoft.EntityFrameworkCore;

namespace DoktorSelector.Models
{
    public class DoktorContext : DbContext
    {
        public DoktorContext(DbContextOptions<DoktorContext> options)
            : base(options)
        {
        }

        public DbSet<DoktorItem> doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}