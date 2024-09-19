using Domain.Progresses;

namespace Domain.Courses.Enrollments;

public class ChapterEnrollment
{
    public Guid ChapterEnrollmentId { get; set; }
    public Guid ChapterId { get; set; }
    public Chapter Chapter { get; set; }
    public ICollection<ChapterProgress> ChapterProgresses { get; set; } = new List<ChapterProgress>();
    public CourseEnrollment CourseEnrollment { get; set; }
    public Guid CourseEnrollmentId { get; set; }
}