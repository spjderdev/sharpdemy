namespace server.DTOs;


public class CourseDTO {
    public int Id {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public decimal Price {get; set;}
    public int Duration {get; set;}
    public string Level {get; set;}
    public int InstructorId {get; set;}
    public string? InstructorName {get; set;}
    public string ImageUrl {get; set;}
}
