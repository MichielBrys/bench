using Domain;
using Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class BenchDbContext : DbContext
{
    public BenchDbContext()
    {
    }

    public BenchDbContext(DbContextOptions<BenchDbContext> options) : base(options)
    {
    }

    public DbSet<Trainee> Trainees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=DESKTOP-97TDGHQ\\SQLEXPRESS;initial catalog=Bench;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.ToTable("Trainees");

            entity.HasKey(e => e.TraineeId);

            entity.Property(e => e.TraineeId)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(e => e.Events)
                .WithOne()
                .HasForeignKey("TraineeId")
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete for the relationship
        });

        // Configure Event entity
        modelBuilder.Entity<Event>(entity =>
        {
            entity.ToTable("Events");

            entity.HasKey(e => e.StreamId);

            entity.Property(e => e.StreamId);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()"); 
        });

        base.OnModelCreating(modelBuilder);
    
    }

}