using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.interfaces;

namespace server.Repositories;


public class CourseRepository : ICourseRepository {
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetCourses() {
        return await _context.Courses.Include(c=> c.Instructor).ToListAsync();
    }
    
    public async Task<Course> GetCourse(int id) {
        return await _context.Courses.Include(c => c.Instructor).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<User> GetInstructorName(int InstructorId) {
        return await _context.Users.FindAsync(InstructorId);
    }

    public async Task<Course> CreateCourse(Course course) {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return course;
    }
}