using Microsoft.EntityFrameworkCore;

namespace FaceCounter.Models
{
    public class HistoryContext : DbContext
    {
        public DbSet<Recognize> Recognizes { get; set; }
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recognize>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("recognize_pk");

                entity.ToTable("recognize");                
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
