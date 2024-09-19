using Domain;
using Domain.Courses;
using Domain.Courses.Enrollments;
using Domain.Events;
using Domain.Progresses;
using Domain.Users;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "data source=DESKTOP-97TDGHQ\\SQLEXPRESS;initial catalog=Bench;Trusted_Connection=True;TrustServerCertificate=True;");
        /*optionsBuilder.UseSqlServer(
            "data source=bm\\SQLEXPRESS;initial catalog=Bench;Trusted_Connection=True;TrustServerCertificate=True;");*/
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
    public DbSet<ChapterEnrollment> ChapterEnrollments { get; set; }
    public DbSet<CourseProgress> CourseProgresses { get; set; }
    public DbSet<ProgressReport> ProgressReports { get; set; }
    public DbSet<ChapterProgress> ChapterProgresses { get; set; }
    public DbSet<CourseEnrollmentTrainer> CourseEnrollmentTrainers { get; set; }
    public DbSet<CourseEnrollmentTrainee> CourseEnrollmentTrainees { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Trainee> Trainees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chapter>()
            .HasOne(ch => ch.Course)
            .WithMany(c => c.Chapters)
            .HasForeignKey(ch => ch.CourseId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from Chapter to Course

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Chapters)
            .WithOne(ch => ch.Course)
            .HasForeignKey(ch => ch.CourseId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from Course to Chapters

        modelBuilder.Entity<Course>()
            .HasMany(c => c.CourseEnrollments)
            .WithOne(ci => ci.Course)
            .HasForeignKey(ci => ci.CourseId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from Course to CourseEnrollments

        modelBuilder.Entity<CourseEnrollment>()
            .HasMany(ci => ci.CourseProgresses)
            .WithOne(cp => cp.CourseEnrollment)
            .HasForeignKey(cp => cp.CourseEnrollmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from CourseEnrollment to CourseProgresses

        modelBuilder.Entity<ChapterEnrollment>()
            .HasMany(ci => ci.ChapterProgresses)
            .WithOne(cp => cp.ChapterEnrollment)
            .HasForeignKey(cp => cp.ChapterEnrollmentId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from ChapterEnrollment to ChapterProgresses

        modelBuilder.Entity<CourseEnrollment>()
            .HasMany(ci => ci.ChapterEnrollments)
            .WithOne(ch => ch.CourseEnrollment)
            .HasForeignKey(ch => ch.CourseEnrollmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from CourseEnrollment to ChapterEnrollments

        modelBuilder.Entity<ChapterEnrollment>()
            .HasOne(ci => ci.Chapter)
            .WithMany(ch => ch.ChapterEnrollments)
            .HasForeignKey(ci => ci.ChapterId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete from ChapterEnrollment to Chapter

        modelBuilder.Entity<CourseEnrollment>()
            .HasMany(ci => ci.CourseEnrollmentTrainers)
            .WithOne(cit => cit.CourseEnrollment)
            .HasForeignKey(cit => cit.CourseEnrollmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from CourseEnrollment to CourseEnrollmentTrainers

        modelBuilder.Entity<CourseEnrollment>()
            .HasMany(ci => ci.CourseEnrollmentTrainees)
            .WithOne(cit => cit.CourseEnrollment)
            .HasForeignKey(cit => cit.CourseEnrollmentId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from CourseEnrollment to CourseEnrollmentTrainees

        modelBuilder.Entity<CourseProgress>()
            .HasMany(cp => cp.ProgressReports)
            .WithOne(pr => pr.CourseProgress)
            .HasForeignKey(pr => pr.CourseProgressId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete from CourseProgress to ProgressReports

        modelBuilder.Entity<CourseProgress>()
            .HasMany(cp => cp.ChapterProgresses)
            .WithOne(cp => cp.CourseProgress)
            .HasForeignKey(cp => cp.CourseProgressId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<CourseEnrollmentTrainer>()
            .HasKey(cit => new { cit.CourseEnrollmentId, cit.TrainerId });
        modelBuilder.Entity<CourseEnrollmentTrainee>()
            .HasKey(cit => new { cit.CourseEnrollmentId, cit.TraineeId });

        // CourseEnrollmentTrainer and Trainer
        modelBuilder.Entity<CourseEnrollmentTrainer>()
            .HasOne(cit => cit.Trainer)
            .WithMany(t => t.EnrollmentTrainers)
            .HasForeignKey("TrainerId");

        // CourseEnrollmentTrainee and Trainee
        modelBuilder.Entity<CourseEnrollmentTrainee>()
            .HasOne(cit => cit.Trainee)
            .WithMany(t => t.CourseEnrollmentTrainees)
            .HasForeignKey("TraineeId");

        // Trainee and CourseProgress
        modelBuilder.Entity<Trainee>()
            .HasMany(t => t.CourseProgresses)
            .WithOne(cp => cp.Trainee)
            .HasForeignKey("TraineeId");

        modelBuilder.Entity<Event>()
            .HasKey(e => e.StreamId);
    }
}