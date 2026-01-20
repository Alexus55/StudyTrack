using Microsoft.EntityFrameworkCore;
using StudyTrack.Api.Models;

namespace StudyTrack.Api.Data
{
    public class StudyTrackContext : DbContext
    {
        public StudyTrackContext(DbContextOptions<StudyTrackContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Subject).HasMaxLength(100);
            });
        }
    }
}