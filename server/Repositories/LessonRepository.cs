using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.interfaces;

namespace server.Repositories;


public class LessonRepository : ILessonRepository {
    private readonly AppDbContext _context;

    public LessonRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Lesson>> GetLessonByCourseId(int courseId) {
        return await _context.Lessons.Where(l => l.CourseId == courseId).ToListAsync();
    }

    public async Task<Lesson> GetLessonById(int id) {
        return await _context.Lessons.FindAsync(id);
    }

    public async Task<Lesson> CreateLesson(Lesson lesson) {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
        return lesson;
    }
}