using Domain.Courses.Enrollments;

namespace Domain.Progresses;

public class ChapterProgress
{
    public Guid ChapterProgressId { get; set; }
    public Guid CourseProgressId { get; set; }
    public Guid ChapterEnrollmentId { get; set; }
    public float PercentageDone { get; set; }
    public CourseProgress CourseProgress { get; set; }
    public ChapterEnrollment ChapterEnrollment { get; set; }
}