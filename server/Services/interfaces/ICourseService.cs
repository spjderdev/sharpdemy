using server.Models;

namespace server.Services.interfaces;


public interface ICourseService {
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> GetCourse(int id); 
    Task<Course> CreateCourse(Course course);
}