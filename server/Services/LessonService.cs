using server.Models;
using server.Repositories.interfaces;
using server.Services.interfaces;

namespace server.Services;

public class LessonService : ILessonService {
    private readonly ILessonRepository _lessonRepository; 

    public LessonService(ILessonRepository lessonRepository) {
        _lessonRepository = lessonRepository;
    }

    public async Task<IEnumerable<Lesson>> GetLessonByCourseId(int courseId) {
        var lesson = await _lessonRepository.GetLessonByCourseId(courseId);
        return lesson;
    }

    public async Task<Lesson> GetLessonById(int id) {
        return await _lessonRepository.GetLessonById(id);
    }

    public async Task<Lesson> CreateLesson(Lesson lesson) {
        return await _lessonRepository.CreateLesson(lesson);
    }
}