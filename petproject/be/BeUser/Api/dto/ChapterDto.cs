namespace Api.dto;

public class ChapterDTO
{
    public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string MaterialUrl { get; set; }

    // Optionally, include CourseId if you want to reference the course
    public Guid CourseId { get; set; }
}