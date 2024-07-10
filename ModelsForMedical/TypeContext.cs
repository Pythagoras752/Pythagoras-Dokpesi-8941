using H_Spot.Models;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public class TypeContext : DbContext
    {
        public TypeContext(DbContextOptions<TypeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Illnesses>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.HasOne(s => s.Illness)
                      .WithMany(i => i.Symptoms)
                      .HasForeignKey(s => s.IllnessId);
            });

            // Seed data or other configurations (if needed)
            modelBuilder.Data();
        }

        public DbSet<Illnesses> Illness { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
    }
}

