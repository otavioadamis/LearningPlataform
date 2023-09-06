using LearningPlataform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlataform.Dal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Lesson>()
            .Property(u => u.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Course>()
            .Property(u => u.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Enrollment>()
            .Property(u => u.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Comment>()
            .Property(u => u.Id)
            .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(u => u.EnrolledCourses)
                .UsingEntity<Enrollment>(
                    j => j.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId),
                    j => j.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId)
                );

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(u => u.CreatedCourses)
                .HasForeignKey(c => c.InstructorId);
        }
    }
}
