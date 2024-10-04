using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Models;
using server.Services.interfaces;

namespace server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase {
    private readonly ICourseService _courseService;
    
    public CourseController(ICourseService courseService) {
        _courseService = courseService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses() {
        var courses = await _courseService.GetCourses();
        var courseList = courses.Select(c => new CourseDTO {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Price = c.Price,
            Duration = c.Duration,
            Level = c.Level.ToString(),
            InstructorId = c.InstructorId,
            InstructorName = c.Instructor.Name,
            ImageUrl = c.ImageUrl
        });

        return Ok(courseList);
    }       

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDTO>> GetCourse(int id) {
        var course = await _courseService.GetCourse(id);

        if(course == null) {
            return NotFound();
        }

        return Ok(course);
    }

   [HttpPost]
    public async Task<ActionResult<CourseDTO>> CreateCourse([FromBody] CourseDTO courseDto)
    {

        if (!Enum.TryParse<Course.CourseLevel>(courseDto.Level, true, out var courseLevel))
        {
            return BadRequest($"Invalid level value: {courseDto.Level}");
        }

        var newCourse = new Course
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Price = courseDto.Price,
            Duration = courseDto.Duration,
            Level = courseLevel,
            InstructorId = courseDto.InstructorId
        };

        var savedCourse = await _courseService.CreateCourse(newCourse);

        var responseCourse = new CourseDTO
        {
            Id = savedCourse.Id,
            Title = savedCourse.Title,
            Description = savedCourse.Description,
            Price = savedCourse.Price,
            Duration = savedCourse.Duration,
            Level = savedCourse.Level.ToString(),
            InstructorId = savedCourse.InstructorId,
            InstructorName = savedCourse.Instructor?.Name
        };
        Console.WriteLine("Level value: " + savedCourse.Level.ToString());
        return Ok(responseCourse);
    }

}