using Domain.Course.Enrollments;

namespace Domain.Course;

public class Chapter
{
    public Guid ChapterId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string MaterialUrl { get; set; }
    
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public ICollection<ChapterEnrollment> ChapterEnrollments { get; set; } = new List<ChapterEnrollment>();
}