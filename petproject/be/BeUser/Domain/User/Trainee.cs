using Domain.Course.Enrollments;
using Domain.Events;
using Domain.Events.Trainee;
using Domain.Progress;

namespace Domain.User;

public class Trainee
{
    public Guid TraineeId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Event> Events { get; set; }
    public ICollection<CourseProgress> CourseProgresses { get; set;  }= new List<CourseProgress>();
    public ICollection<CourseEnrollmentTrainee> CourseEnrollmentTrainees { get; set; } = new List<CourseEnrollmentTrainee>();

    public void Append(Event @event)
    {
        Events.Add(@event);
    }
    public void Apply(TraineeUpdated traineeUpdated)
    {
        Name = traineeUpdated.Name;
    }
}