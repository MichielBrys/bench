using Domain.Courses.Enrollments;
using Domain.Users;

namespace Domain.Progresses;

public class CourseProgress
{
    public Guid CourseProgressId { get; set; }
    public Guid TraineeId { get; set; }
    public Guid CourseEnrollmentId { get; set; }
    public float PercentageDone { get; set; }
    public ICollection<ProgressReport> ProgressReports { get; set; }
    public ICollection<ChapterProgress> ChapterProgresses { get; set; }
    public CourseEnrollment CourseEnrollment { get; set; }
    public Trainee Trainee { get; set; }
}