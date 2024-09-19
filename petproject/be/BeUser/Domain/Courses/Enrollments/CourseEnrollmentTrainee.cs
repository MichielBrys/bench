using Domain.Users;

namespace Domain.Courses.Enrollments;

public class CourseEnrollmentTrainee
{
    
    public Guid CourseEnrollmentId { get; set; }
    public Guid TraineeId { get; set; }
    public CourseEnrollment CourseEnrollment { get; set; }
    public Trainee Trainee { get; set; }
}