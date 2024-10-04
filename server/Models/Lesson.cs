using System.ComponentModel.DataAnnotations;

namespace server.Models;


public class Lesson {
    [Key]
    public int Id {get; set;}
    
    [Required]
    public string Title {get; set;}

    public string Description {get; set;}

    [Required]
    public string Content {get; set;}

    [Required]
    public int CourseId {get; set;}
    
    public Course? Course {get; set;}
    public int Duration {get; set;}
}