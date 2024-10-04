using server.Models;

namespace server.Services.interfaces;


public interface ILessonService {
    Task<IEnumerable<Lesson>> GetLessonByCourseId(int courseId);
    Task<Lesson> GetLessonById(int id);
    Task<Lesson> CreateLesson(Lesson lesson);
}