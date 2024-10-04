using server.Repositories.interfaces;
using server.Services.interfaces;
using server.Models;
using server.DTOs;

namespace server.Services;


public class CourseService : ICourseService {
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository) {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Course>> GetCourses() {
        var courses = await _courseRepository.GetCourses();
        return (courses.Select(c => new Course {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Price = c.Price,
            Duration = c.Duration,
            Level = c.Level,
            InstructorId = c.Instructor.Id,
            Instructor = new User {
                Name = c.Instructor.Name
            },
            ImageUrl = c.ImageUrl
        }));
    }

    public async Task<Course> GetCourse(int id) {
        var course = await _courseRepository.GetCourse(id);
        if(course == null) {
            return null;
        }
        return new Course {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description,
            Price = course.Price,
            Duration = course.Duration,
            Level = course.Level,
            Instructor = new User {
                Name = course.Instructor.Name
            }
        };
    }

    public async Task<Course> CreateCourse(Course course) {
        var instructor = await _courseRepository.GetInstructorName(course.InstructorId);
        course.Instructor = instructor; 
        var courses = await _courseRepository.CreateCourse(course);
        return courses;
    }
}