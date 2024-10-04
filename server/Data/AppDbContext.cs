using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;


public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

    }

    public DbSet<User> Users {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Lesson> Lessons {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

        modelBuilder.Entity<User>().HasData(
            new User {
                Id = 1,
                Name = "John Doe",
                Email = "instructortest@mail.com",
                Password = "123456",
                Role = "Instructor"
            },
            new User {
                Id = 2,
                Name = "Michael Jackson",
                Email ="instructor1@mail.com",
                Password = "123456",
                Role = "Instructor"
            }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course {
                Id = 1,
                Title = "Introduction to C#",
                Description = "A Beginner course for learning C# programming",
                Price = 100,
                InstructorId = 1,
                Duration = 30,
                Level = 0,
                ImageUrl = "image.jpg"
            }
        );

        modelBuilder.Entity<Lesson>().HasData(
            new Lesson {
                Id = 1,
                Title = "Lesson 1: Variables in C#",
                Description = "This lesson will let you know something in C#",
                Content = "videourl.com",
                CourseId = 1,
                Duration = 10
            }
        );
    }
}