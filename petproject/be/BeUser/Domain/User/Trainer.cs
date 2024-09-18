using Domain.Course.Enrollments;

namespace Domain.User;

public class Trainer
{
    public Guid TrainerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public ICollection<CourseEnrollmentTrainer> EnrollmentTrainers { get; set; } = new List<CourseEnrollmentTrainer>();

}