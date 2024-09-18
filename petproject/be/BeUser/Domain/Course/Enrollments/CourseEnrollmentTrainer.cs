using Domain.User;

namespace Domain.Course.Enrollments;

public class CourseEnrollmentTrainer
{
    public Guid CourseEnrollmentId { get; set; }
    public Guid TrainerId { get; set; }

    public CourseEnrollment CourseEnrollment { get; set; }
    public Trainer Trainer { get; set; }
}