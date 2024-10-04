using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


public class Course {
    public enum CourseLevel {
        Beginners,
        Advanced,
        Pro
    }
    [Key]
    public int Id {get; set;}

    [Required]
    public string Title {get; set;}

    [Required]
    public string Description {get; set;}

    [Required]
    [Column(TypeName = "decimal(18,2)")]

    public decimal Price {get; set;}

    public int Duration {get; set;}

    [Required]
    public CourseLevel Level {get; set;}

    [Required]
    public string ImageUrl {get; set;}

    [ForeignKey("Instructor")]
    public int InstructorId {get; set;}
    public User Instructor {get; set;}

}
