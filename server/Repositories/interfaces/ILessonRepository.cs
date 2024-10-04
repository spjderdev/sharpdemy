using server.Models;

namespace server.Repositories.interfaces;


public interface ILessonRepository {
    Task<IEnumerable<Lesson>> GetLessonByCourseId(int courseId);
    Task<Lesson> GetLessonById(int id);

    Task<Lesson> CreateLesson(Lesson lesson);
}