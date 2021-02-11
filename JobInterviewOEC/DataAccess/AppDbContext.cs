using Microsoft.EntityFrameworkCore;

namespace JobInterviewOEC.DataAccess
{
    internal class AppDbContext : DbContext
    {
        public DbSet<AtlasData> AtlasData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtlasDataTypeConfiguration());
        }
    }
}
