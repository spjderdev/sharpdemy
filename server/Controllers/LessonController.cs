using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.interfaces;

namespace server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase {
    private readonly ILessonService _lessonService;
    public LessonController(ILessonService lessonService) {
            _lessonService = lessonService;
    }

    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetLessonByCourseId(int courseId) {
        var lesson = await _lessonService.GetLessonByCourseId(courseId);
        return Ok(lesson);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(int id) {
        var lesson = await _lessonService.GetLessonById(id);
        return Ok(lesson);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLesson([FromBody] Lesson lesson) {
        if(lesson == null) {
            throw new Exception("Invalid lesson");
        }
        var CreatedLesson = await _lessonService.CreateLesson(lesson);

        if(CreatedLesson == null) {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetLessonById), new {id = CreatedLesson.Id}, CreatedLesson);
    }
}