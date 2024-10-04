using server.Models;

namespace server.Repositories.interfaces;


public interface ICourseRepository {
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> GetCourse(int id);
    Task<Course> CreateCourse(Course course);
    Task<User> GetInstructorName(int instructorId);
}