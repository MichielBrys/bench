namespace Api.dto;


public class CourseDTO
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    // Optionally, include a list of ChapterDTOs if you want to include chapters in the course DTO
    public IEnumerable<ChapterDTO> Chapters { get; set; } = new List<ChapterDTO>();
}